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

	public class PlayerGameMapController : ControllerBase
	{
        SportsClubManagementContext DbContext { get; set; }

        public PlayerGameMapController(SportsClubManagementContext DbContext)  //TODO: Explain Depedency Injection
        {
            this.DbContext = DbContext;
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.PlayerGameMapSelectList)]
        public IActionResult PlayerGameMapList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.PlayerGameMap.ToList();

            return Ok(response);
        }

        [HttpPost(ActionConts.PlayerGameMapSelectById)]
        public IActionResult PlayerGameMapSelectById([FromBody] BaseIdRequest request)
        {
            var response = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.PlayerGameMapSelectForDropdown)]
        public IActionResult PlayerGameMapSelectForDropdown([FromBody] BaseIdRequest request)
        {
            var response = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.PlayerGameMapInsert)]
        public async Task<IActionResult> PlayerGameMapInsert([FromBody] BaseIdRequest request)
        {
            await DbContext.PlayerGameMap.AddAsync(new PlayerGameMap
            {
                
            });;
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.PlayerGameMapDelete)]
        public async Task<IActionResult> PlayerGameMapDelete([FromBody] BaseIdRequest request)
        {
            var PlayerGameMap = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.PlayerGameMap.Remove(PlayerGameMap);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
