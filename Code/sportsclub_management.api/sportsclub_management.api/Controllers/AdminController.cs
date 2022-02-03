using Microsoft.AspNetCore.Mvc;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	[Route("api/v1/")]
	[ApiController]

	public class AdminController : ControllerBase
	{
        SportsClubManagementContext DbContext { get; set; }

        public AdminController(SportsClubManagementContext DbContext)  //TODO: Explain Depedency Injection
        {
            this.DbContext = DbContext;
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.AdminSelectList)]
        public IActionResult AdminList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.Admin.ToList();

            return Ok(response);
        }

        [HttpPost(ActionConts.AdminSelectById)]
        public IActionResult AdminSelectById([FromBody] BaseIdRequest request)
        {
            var response = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.AdminSelectForDropdown)]
        public IActionResult AdminSelectForDropdown([FromBody] BaseIdRequest request)
        {
            var response = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.AdminInsert)]
        public async Task<IActionResult> AdminInsert([FromBody] BaseIdRequest request)
        {
            await DbContext.Admin.AddAsync(new Admin
            {
                Name = "Tanvi",
            });
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.AdminDelete)]
        public async Task<IActionResult> AdminDelete([FromBody] BaseIdRequest request)
        {
            var Admin = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.Admin.Remove(Admin);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
