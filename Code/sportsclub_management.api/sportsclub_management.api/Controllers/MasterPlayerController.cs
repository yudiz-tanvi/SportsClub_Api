using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.Base.MasterPlayer;
using sportsclub_management.models.Requests.MasterPlayer;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class MasterPlayerController : BaseController
	{
        public MasterPlayerController(SportsClubManagementContext DbContext, ICrypto Crypto) : base(DbContext, Crypto)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterPlayerSelectList)]
        public IActionResult MasterPlayerList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterPlayer
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterPlayerSelectById)]
        public IActionResult MasterPlayerSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.MasterPlayer.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterPlayerSelectForDropdown)]
        public IActionResult MasterPlayerSelectForDropdown()
        {
            var response = DbContext.MasterPlayer
                .Where(x => !x.Deleted && x.Active)
                .Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterPlayerInsert)]
        public async Task<IActionResult> MasterPlayerInsert([FromBody] MasterPlayerInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            if (DbContext.MasterPlayer.Any(x => x.AadharNumber.Equals(request.Name)))
                return ErrorResponse("Aadhar Number Already Exists");

            await DbContext.MasterPlayer.AddAsync(new MasterPlayer
            {
                Name = request.Name,
                Mobile = request.Mobile,
                AadharNumber = request.AadharNumber,
                Fees = request.Fees,
                Email = request.Email,
                JoiningDate = DateTime.Now,
            }) ;
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterPlayerUpdate)]
        public async Task<IActionResult> MasterPlayerUpdateAsync([FromBody] MasterPlayerUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var masterplayer = new MasterPlayerMap().Map(request);

            DbContext.MasterPlayer.Update(masterplayer);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterPlayerDelete)]
        public async Task<IActionResult> MasterPlayerDelete([FromBody] BaseIdRequest request)
        {
            var masterPlayer = DbContext.MasterPlayer.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterPlayer.Remove(masterPlayer);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterPlayerSoftDelete)]
        public async Task<IActionResult> MasterPlayerSoftDelete([FromBody] BaseIdRequest request)
        {
            var masterPlayer = DbContext.MasterPlayer.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (masterPlayer.Deleted == false)
            {
                masterPlayer.Deleted = true;
            }

            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
