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

    public class CoachAddressController : ControllerBase
	{
        SportsClubManagementContext DbContext { get; set; }

        public CoachAddressController(SportsClubManagementContext DbContext)  //TODO: Explain Depedency Injection
        {
            this.DbContext = DbContext;
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.CoachAddressSelectList)]
        public IActionResult CoachAddressList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.CoachAddress.ToList();

            return Ok(response);
        }

        [HttpPost(ActionConts.CoachAddressSelectById)]
        public IActionResult CoachAddressSelectById([FromBody] BaseIdRequest request)
        {
            var response = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.CoachAddressSelectForDropdown)]
        public IActionResult CoachAddressSelectForDropdown([FromBody] BaseIdRequest request)
        {
            var response = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.CoachAddressInsert)]
        public async Task<IActionResult> CoachAddressInsert([FromBody] BaseIdRequest request)
        {
            await DbContext.CoachAddress.AddAsync(new CoachAddress
            {
                Coach_Address = "P.D.M. College,Gondal Road",
                
            });
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.CoachAddressDelete)]
        public async Task<IActionResult> CoachAddressDelete([FromBody] BaseIdRequest request)
        {
            var CoachAddress = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.CoachAddress.Remove(CoachAddress);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
