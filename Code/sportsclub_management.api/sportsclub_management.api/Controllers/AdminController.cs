using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Admin;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class AdminController : BaseController
	{
        public AdminController(SportsClubManagementContext DbContext) : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.AdminSelectList)]
        public IActionResult AdminList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.Admin
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminSelectById)]
        public IActionResult AdminSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminSelectForDropdown)]
        public IActionResult AdminSelectForDropdown()
        {
            var response = DbContext.Admin.Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminInsert)]
        public async Task<IActionResult> AdminInsert([FromBody] AdminInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.Admin.AddAsync(new Admin
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username,
                Mobile = request.Mobile,
                Gender = request.Gender,
                MasterRoleId = request.MasterRoleId,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.AdminDelete)]
        public async Task<IActionResult> AdminDelete([FromBody] BaseIdRequest request)
        {
            var Admin = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.Admin.Remove(Admin);
            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
