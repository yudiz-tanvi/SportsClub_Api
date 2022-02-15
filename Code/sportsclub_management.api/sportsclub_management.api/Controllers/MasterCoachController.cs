using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterCoach;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class MasterCoachController : BaseController
    {
        public MasterCoachController(SportsClubManagementContext DbContext, ICrypto Crypto) : base(DbContext, Crypto)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterCoachSelectList)]
        public IActionResult MasterCoachList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterCoach
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterCoachSelectById)]
        public IActionResult MasterCoachSelectById([FromBody] BaseIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.MasterCoach.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterCoachSelectForDropdown)]
        public IActionResult MasterCoachSelectForDropdown()
        {
            var response = DbContext.MasterCoach
                .Where(x => !x.Deleted && x.Active)
                .Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterCoachInsert)]
        public async Task<IActionResult> MasterCoachInsert([FromBody] MasterCoachInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            if (DbContext.MasterCoach.Any(x => x.AadharNumber.Equals(request.Name)))
                return ErrorResponse("AadharNumber Already Exists");

            await DbContext.MasterCoach.AddAsync(new MasterCoach
            {
                Name = request.Name,
                Mobile = request.Mobile,
                AadharNumber = request.AadharNumber,
                MasterGameId = request.MasterGameId,

            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterCoachUpdate)]
        public async Task<IActionResult> MasterCoachUpdateAsync([FromBody] MasterCoachUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var mastercoach = new MasterCoachMap().Map(request);

            DbContext.MasterCoach.Update(mastercoach);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterCoachDelete)]
        public async Task<IActionResult> MasterCoachDelete([FromBody] BaseIdRequest request)
        {
            var MasterCoach = DbContext.MasterCoach.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterCoach.Remove(MasterCoach);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterCoachSoftDelete)]
        public async Task<IActionResult> MasterCoachSoftDelete([FromBody] BaseIdRequest request)
        {
            var MasterCoach = DbContext.MasterCoach.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (MasterCoach.Deleted == false)
            {
                MasterCoach.Deleted = true;
            }

            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
