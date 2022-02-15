using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterGame;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
    public class MasterGameController : BaseController
    {
        public MasterGameController(SportsClubManagementContext DbContext, ICrypto Crypto) : base(DbContext, Crypto)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterGameSelectList)]
        public IActionResult MasterGameList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            
            var response = DbContext.MasterGame
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x=>!x.Deleted)
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
            var response = DbContext.MasterGame
                .Where(x => !x.Deleted && x.Active)
                .Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterGameInsert)]
        public async Task<IActionResult> MasterGameInsert([FromBody] MasterGameInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            // Check if name already exists in database
            if (DbContext.MasterGame.Any(x => x.Name.Equals(request.Name)))
                return ErrorResponse("Game Already Exists");

            await DbContext.MasterGame.AddAsync(new MasterGame
            {
                Name = request.Name,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterGameUpdate)]
        public async Task<IActionResult> MasterGameUpdateAsync([FromBody] MasterGameUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var mastergame = new MasterGameMap().Map(request);

            DbContext.MasterGame.Update(mastergame);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterGameDelete)]
        public async Task<IActionResult> MasterGameDelete([FromBody] BaseIdRequest request)
        {
            var MasterGame = DbContext.MasterGame.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterGame.Remove(MasterGame);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterGameSoftDelete)]
        public async Task<IActionResult> MasterGameSoftDelete([FromBody] BaseIdRequest request)
        {
            var MasterGame = DbContext.MasterGame.FirstOrDefault(x => x.Id.Equals(request.Id));

            if(MasterGame.Deleted == false)
            {
                MasterGame.Deleted = true;
            }
               
            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
