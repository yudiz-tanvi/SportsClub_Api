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

	public class GameEquipmentMapController : ControllerBase
	{
        SportsClubManagementContext DbContext { get; set; }

        public GameEquipmentMapController(SportsClubManagementContext DbContext)  //TODO: Explain Depedency Injection
        {
            this.DbContext = DbContext;
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.GameEquipmentMapSelectList)]
        public IActionResult GameEquipmentMapList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.GameEquipmentMap.ToList();

            return Ok(response);
        }

        [HttpPost(ActionConts.GameEquipmentMapSelectById)]
        public IActionResult GameEquipmentMapSelectById([FromBody] BaseIdRequest request)
        {
            var response = DbContext.GameEquipmentMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.GameEquipmentMapSelectForDropdown)]
        public IActionResult GameEquipmentMapSelectForDropdown([FromBody] BaseIdRequest request)
        {
            var response = DbContext.GameEquipmentMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.GameEquipmentMapInsert)]
        public async Task<IActionResult> GameEquipmentMapInsert([FromBody] BaseIdRequest request)
        {
            await DbContext.GameEquipmentMap.AddAsync(new GameEquipmentMap
            {
                Quantity = 10 ,
                Remarks = "Good",
                
            }); ;
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.GameEquipmentMapDelete)]
        public async Task<IActionResult> GameEquipmentMapDelete([FromBody] BaseIdRequest request)
        {
            var GameEquipmentMap = DbContext.GameEquipmentMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.GameEquipmentMap.Remove(GameEquipmentMap);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
