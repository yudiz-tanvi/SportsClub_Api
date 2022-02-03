using Microsoft.AspNetCore.Mvc;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	[Route("api/v1/")]
	[ApiController]

	public class FeedbackController : ControllerBase
	{
        SportsClubManagementContext DbContext { get; set; }

        public FeedbackController(SportsClubManagementContext DbContext)  //TODO: Explain Depedency Injection
        {
            this.DbContext = DbContext;
        }

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.FeedbackSelectList)]
        public IActionResult FeedbackList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.Feedback.ToList();

            return Ok(response);
        }

        [HttpPost(ActionConts.FeedbackSelectById)]
        public IActionResult FeedbackSelectById([FromBody] BaseIdRequest request)
        {
            var response = DbContext.Feedback.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.FeedbackSelectForDropdown)]
        public IActionResult FeedbackSelectForDropdown([FromBody] BaseIdRequest request)
        {
            var response = DbContext.Feedback.FirstOrDefault(x => x.Id.Equals(request.Id));

            return Ok(response);
        }

        [HttpPost(ActionConts.FeedbackInsert)]
        public async Task<IActionResult> FeedbackInsert([FromBody] BaseIdRequest request)
        {
            await DbContext.Feedback.AddAsync(new Feedback
            {
                Add_Feedback = "Good",
                
            });
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpPost(ActionConts.FeedbackDelete)]
        public async Task<IActionResult> FeedbackDelete([FromBody] BaseIdRequest request)
        {
            var Feedback = DbContext.Feedback.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.Feedback.Remove(Feedback);
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
