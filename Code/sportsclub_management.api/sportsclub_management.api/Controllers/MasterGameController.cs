using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterGame;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class MasterGameController : BaseController
	{
        public MasterGameController(SportsClubManagementContext DbContext)  : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterGameSelectList)]
        public IActionResult MasterGameList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterGame
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterGameSelectById)]
        public IActionResult MasterGameSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.MasterGame.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterGameSelectForDropdown)]
        public IActionResult MasterGameSelectForDropdown()
        {
            var response = DbContext.MasterGame.Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterPlayerInsert)]
        public async Task<IActionResult> MasterPlayerInsert([FromBody] MasterGameInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.MasterPlayer.AddAsync(new MasterPlayer
            {
                Name = request.Name,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterGameDelete)]
        public async Task<IActionResult> MasterGameDelete([FromBody] BaseIdRequest request)
        {
            var masterGame = DbContext.MasterGame.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterGame.Remove(masterGame);
            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
