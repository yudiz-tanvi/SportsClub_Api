using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.GameEquipmentMap;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
    public class gameEquipmentController : BaseController
    {
        public gameEquipmentController(SportsClubManagementContext DbContext) : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.GameEquipmentMapSelectList)]
        public IActionResult GameEquipmentMapList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.GameEquipmentMap
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page

            return OkResponse(response);
        }

        [HttpPost(ActionConts.GameEquipmentMapSelectById)]
        public IActionResult GameEquipmentMapSelectById([FromBody] BaseIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.GameEquipmentMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        //[HttpPost(ActionConts.GameEquipmentMapSelectForDropdown)]
        //public IActionResult GameEquipmentMapSelectForDropdown()
        //{
        //    var response = DbContext.GameEquipmentMap.Select(x => new { x.Name, x.Id });
        //
        //    return OkResponse(response);
        //}

        [HttpPost(ActionConts.GameEquipmentMapInsert)]
        public async Task<IActionResult> GameEquipmentMapInsert([FromBody] GameEquipmentMapInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.GameEquipmentMap.AddAsync(new GameEquipmentMap
            {
                Quantity = request.Quantity,
                Remarks = request.Remarks,
                MasterGameId = request.MasterGameId,
                MasterEquipmentId = request.MasterEquipmentId,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.GameEquipmentMapDelete)]
        public async Task<IActionResult> GameEquipmentMapDelete([FromBody] BaseIdRequest request)
        {
            var GameEquipmentMap = DbContext.GameEquipmentMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.GameEquipmentMap.Remove(GameEquipmentMap);
            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
