using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.MasterEquipment;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class MasterEquipmentController :BaseController
	{
        public MasterEquipmentController(SportsClubManagementContext DbContext) : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.MasterEquipmentSelectList)]
        public IActionResult MasterEquipmentList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.MasterEquipment
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
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
            var response = DbContext.MasterEquipment.Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.MasterEquipmentInsert)]
        public async Task<IActionResult> MasterEquipmentInsert([FromBody] MasterEquipmentInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.MasterEquipment.AddAsync(new MasterEquipment
            {
                Name = request.Name,
                Quantity = request.Quantity,
            });
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
    }
}
