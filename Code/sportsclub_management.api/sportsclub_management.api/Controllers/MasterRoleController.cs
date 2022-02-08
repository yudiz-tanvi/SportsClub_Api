using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterRole;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
    public class MasterRoleController : BaseController
    {
        public MasterRoleController(SportsClubManagementContext DbContext) : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterRoleSelectList)]
        public IActionResult MasterRoleList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterRole
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterRoleSelectById)]
        public IActionResult MasterRoleSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.MasterRole.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterRoleSelectForDropdown)]
        public IActionResult MasterRoleSelectForDropdown()
        {
            var response = DbContext.MasterRole.Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterRoleInsert)]
        public async Task<IActionResult> MasterRoleInsert([FromBody] MasterRoleInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.MasterRole.AddAsync(new MasterRole
            {
                Name = request.Name,
                Display_Name = request.Display_Name,
            });
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.MasterRoleDelete)]
        public async Task<IActionResult> MasterRoleDelete([FromBody] BaseIdRequest request)
        {
            var MasterRole = DbContext.MasterRole.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterRole.Remove(MasterRole);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
