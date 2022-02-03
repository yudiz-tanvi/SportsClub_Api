using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportsclub_management.api.Filters;
using sportsclub_management.models.Constants;
using sportsclub_management.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers.Base
{
    [ServiceFilter(typeof(ExceptionFilters))]
    [ApiController]
    [Route(ActionConts.ApiVersion)]
    public class BaseController : ControllerBase
	{
        #region Object Declarations and Constructor

        public SportsClubManagementContext DbContext { get; set; }

        public BaseController(SportsClubManagementContext DbContext)
        {
            this.DbContext = DbContext;
        }

        #endregion

        #region OkResponse

        protected IActionResult OkResponse() => Ok(new
        {
            meta = new
            {
                message = "Your Request Has Been Performed Successfully",
                statusCode = 200
            }
        });

        protected IActionResult OkResponse(string message) => Ok(new
        {
            meta = new { message = message, statusCode = 200 }
        });

        protected IActionResult OkResponse(string message, object data) => Ok(new
        {
            meta = new { message = message, statusCode = 200 },
            data = data
        });

        protected IActionResult OkResponse(object data) => Ok(new
        {
            meta = new { message = "Your Request Has Been Performed Successfully", statusCode = 200 },
            data = data
        });

        protected IActionResult OkResponse(IEnumerable<dynamic> details)
        {
            var data = new { details };
            return Ok(new
            {
                meta = new { message = "Your Request Has Been Performed Successfully", statusCode = 200 },
                data
            });
        }
        #endregion OkResponse

        #region Failed Response

        protected IActionResult ErrorResponse() => throw new ApiException("error_something_went_wrong", 400);

        protected IActionResult ErrorResponse(string message) => throw new ApiException(message, 400);

        protected IActionResult ErrorResponse(string message, int statusCode) => throw new ApiException(message, statusCode);

        protected IActionResult ErrorResponse(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary ModelState)
        {
            string message = string.Join("; ", ModelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage));
            throw new ApiException(message, 400);
        }

        protected IActionResult ErrorResponse(IEnumerable<dynamic> data, string message)
        {
            throw new ApiException(message, 400, data);
        }

        protected IActionResult ErrorMarkorResponse(object message) => BadRequest(new { message });

        #endregion Failed Response
    }
}
