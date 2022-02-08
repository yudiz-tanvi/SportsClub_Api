using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Requests.Feedback;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class FeedbackController : BaseController
	{
        public FeedbackController(SportsClubManagementContext DbContext) : base(DbContext)  //TODO: Explain Depedency Injection
        {
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.FeedbackSelectList)]
        public IActionResult FeedbackList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.Feedback
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.FeedbackSelectById)]
        public IActionResult FeedbackSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.Feedback.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        //[HttpPost(ActionConts.FeedbackSelectForDropdown)]
        //public IActionResult FeedbackSelectForDropdown()
        //{
        //    var response = DbContext.Feedback.Select(x => new { x.Name, x.Id });
        //
        //    return OkResponse(response);
        //}

        [HttpPost(ActionConts.FeedbackInsert)]
        public async Task<IActionResult> FeedbackInsert([FromBody] FeedbackInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            await DbContext.Feedback.AddAsync(new Feedback
            {
                Add_Feedback = request.Add_Feedback,
                MasterPlayerId = request.MasterPlayerId,
                MasterGameId = request.MasterGameId,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.FeedbackDelete)]
        public async Task<IActionResult> FeedbackDelete([FromBody] BaseIdRequest request)
        {
            var Feedback = DbContext.Feedback.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.Feedback.Remove(Feedback);
            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
