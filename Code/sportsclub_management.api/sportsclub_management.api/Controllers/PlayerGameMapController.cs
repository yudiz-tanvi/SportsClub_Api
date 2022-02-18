using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.PlayerGameMap;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class PlayerGameMapController : BaseController
	{
        public PlayerGameMapController(SportsClubManagementContext DbContext, ICrypto Crypto, IStringLocalizer<BaseController> Localizer)
            : base(DbContext, Crypto, Localizer)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.PlayerGameMapSelectList)]
        public IActionResult PlayerGameMapList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.PlayerGameMap
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page

            return OkResponse(response);
        }

        [HttpPost(ActionConts.PlayerGameMapSelectById)]
        public IActionResult PlayerGameMapSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        //[HttpPost(ActionConts.PlayerGameMapSelectForDropdown)]
        //public IActionResult PlayerGameMapSelectForDropdown()
        //{
          //  var response = DbContext.PlayerGameMap.Select(x => new { x.Name, x.Id });

            //return OkResponse(response);
        //}

        [HttpPost(ActionConts.PlayerGameMapInsert)]
        public async Task<IActionResult> PlayerGameMapInsert([FromBody] PlayerGameMapInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.PlayerGameMap.AddAsync(new PlayerGameMap
            {
                MasterPlayerId = request.MasterPlayerId,
                MasterGameId = request.MasterGameId,

            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.PlayerGameMapUpdate)]
        public async Task<IActionResult> PlayerGameMapUpdateAsync([FromBody] PlayerGameMapUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var playergamemap = new PlayerGameMapMap().Map(request);

            DbContext.PlayerGameMap.Update(playergamemap);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.PlayerGameMapDelete)]
        public async Task<IActionResult> PlayerGameMapDelete([FromBody] BaseIdRequest request)
        {
            var PlayerGameMap = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.PlayerGameMap.Remove(PlayerGameMap);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.PlayerGameMapSoftDelete)]
        public async Task<IActionResult> PlayerGameMapSoftDelete([FromBody] BaseIdRequest request)
        {
            var PlayerGameMap = DbContext.PlayerGameMap.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (PlayerGameMap.Deleted == false)
            {
                PlayerGameMap.Deleted = true;
            }

            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
