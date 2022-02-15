using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.CoachAddress;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
    public class CoachAddressController : BaseController
	{
       public CoachAddressController(SportsClubManagementContext DbContext, ICrypto Crypto) : base(DbContext, Crypto)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.CoachAddressSelectList)]
        public IActionResult CoachAddressList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.CoachAddress
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.CoachAddressSelectById)]
        public IActionResult CoachAddressSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        //[HttpPost(ActionConts.CoachAddressSelectForDropdown)]
        //public IActionResult CoachAddressSelectForDropdown()
        //{
        //    var response = DbContext.CoachAddress.Select(x => new { x.Coach_Address, x.Id });
        //
        //    return OkResponse(response);
        //}

        [HttpPost(ActionConts.CoachAddressInsert)]
        public async Task<IActionResult> CoachAddressInsert([FromBody] CoachAddressInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.CoachAddress.AddAsync(new CoachAddress
            {
                Address = request.Address,
                MasterCoachId = request.MasterCoachId,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.CoachAddressUpdate)]
        public async Task<IActionResult> CoachAddressUpdateAsync([FromBody] CoachAddressUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var coachaddress = new CoachAddressMap().Map(request);

            DbContext.CoachAddress.Update(coachaddress);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.CoachAddressDelete)]
        public async Task<IActionResult> CoachAddressDelete([FromBody] BaseIdRequest request)
        {
            var CoachAddress = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.CoachAddress.Remove(CoachAddress);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.CoachAddressSoftDelete)]
        public async Task<IActionResult> CoachAddressSoftDelete([FromBody] BaseIdRequest request)
        {
            var CoachAddress = DbContext.CoachAddress.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.CoachAddress.Remove(CoachAddress);
            DbContext.SaveChanges();

            return OkResponse();
        }

    }
}
