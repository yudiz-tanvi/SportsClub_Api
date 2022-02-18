using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterEquipment;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class MasterEquipmentController :BaseController
	{
        public MasterEquipmentController(SportsClubManagementContext DbContext, ICrypto Crypto, IStringLocalizer<BaseController> Localizer)
            : base(DbContext, Crypto, Localizer)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterEquipmentSelectList)]
        public IActionResult MasterEquipmentList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterEquipment
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterEquipmentSelectById)]
        public IActionResult MasterEquipmentSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.MasterEquipment.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterEquipmentSelectForDropdown)]
        public IActionResult MasterEquipmentSelectForDropdown()
        {
            var response = DbContext.MasterEquipment
                .Where(x => !x.Deleted && x.Active)
                .Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterEquipmentInsert)]
        public async Task<IActionResult> MasterEquipmentInsert([FromBody] MasterEquipmentInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            if (DbContext.MasterEquipment.Any(x => x.Name.Equals(request.Name)))
                return ErrorResponse("equipment Already Exists");

            await DbContext.MasterEquipment.AddAsync(new MasterEquipment
            {
                Name = request.Name,
                Quantity = request.Quantity,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterEquipmentUpdate)]
        public async Task<IActionResult> MasterEquipmentUpdateAsync([FromBody] MasterEquipmentUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var masterequipment = new MasterEquipmentMap().Map(request);

            DbContext.MasterEquipment.Update(masterequipment);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterEquipmentDelete)]
        public async Task<IActionResult> MasterEquipmentDelete([FromBody] BaseIdRequest request)
        {
            var MasterEquipment = DbContext.MasterEquipment.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.MasterEquipment.Remove(MasterEquipment);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.MasterEquipmentSoftDelete)]
        public async Task<IActionResult> MasterEquipmentSoftDelete([FromBody] BaseIdRequest request)
        {
            var MasterEquipment = DbContext.MasterEquipment.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (MasterEquipment.Deleted == false)
            {
                MasterEquipment.Deleted = true;
            }

            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
