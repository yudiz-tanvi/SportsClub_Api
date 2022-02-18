using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using sportsclub_management.api.Filters;
using sportsclub_management.models;
using sportsclub_management.models.Constants;
using sportsclub_management.repository;
using sportsclub_management.security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers.Base
{
    [ServiceFilter(typeof(ExceptionFilters))]
    [ApiController]
    [Route(ActionConts.ApiVersion)]
    public class BaseController : ControllerBase
	{
        #region Object Declarations and Constructor

        protected SportsClubManagementContext DbContext { get; set; }

        protected Admin Admin { get; set; }

        protected ICrypto Crypto { get; set; }

        protected IStringLocalizer<BaseController> Localizer { get; set; }

        public BaseController(SportsClubManagementContext DbContext, ICrypto Crypto, IStringLocalizer<BaseController> Localizer)
        {
            this.DbContext = DbContext;
            this.Crypto = Crypto;
            this.Localizer = Localizer;
        }

        #endregion

        #region OkResponse

        protected IActionResult OkResponse() => Ok(new
        {
            meta = new
            {
                message = Localizer["ok_response_successful"].Value,
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
            meta = new { message = Localizer["ok_response_successful"].Value, statusCode = 200 },
            data = data
        });

        protected IActionResult OkResponse(IEnumerable<dynamic> details)
        {
            var data = new { details };
            return Ok(new
            {
                meta = new { message = Localizer["ok_response_successful"].Value, statusCode = 200 },
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

        #region Get current admin's data using Token

        protected bool IsLoggedIn(ClaimsPrincipal Admin) => Admin.Identity.IsAuthenticated;

        protected Guid GetAdminId(ClaimsPrincipal Admin)
        {
            var admin_id = Admin.Claims.Where(x => x.Type.Equals(JwtRegisteredClaimNames.Sid))?.FirstOrDefault().Value;
            if (admin_id is null) return Guid.Empty;
            return Guid.Parse(Crypto.Decrypt(admin_id));
        }

        protected string GetAdminEmail(ClaimsPrincipal Admin)
        {
            var email = Admin.Claims.Where(x => x.Type.Equals(ClaimTypes.Email))?.FirstOrDefault().Value;
            if (email is null) return string.Empty;
            return Crypto.Decrypt(email);
        }

        protected string GetAdminFullName(ClaimsPrincipal Admin)
        {
            var givenName = Admin.Claims.Where(x => x.Type.Equals(ClaimTypes.GivenName))?.FirstOrDefault().Value;
            if (givenName is null) return string.Empty;
            return Crypto.Decrypt(givenName);
        }

        protected string GetAdminName(ClaimsPrincipal Admin)
        {
            var adminName = Admin.Claims.Where(x => x.Type.Equals("Adminame"))?.FirstOrDefault().Value;
            if (adminName is null) return string.Empty;
            return Crypto.Decrypt(adminName);
        }

        protected string GetUniqueId(ClaimsPrincipal Admin)
        {
            var uniqueId = Admin.Claims.Where(x => x.Type.Equals(JwtRegisteredClaimNames.Jti))?.FirstOrDefault().Value;
            if (uniqueId is null) return string.Empty;
            return Crypto.Decrypt(uniqueId);
        }

        protected string GetAdminRole(ClaimsPrincipal Admin)
        {
            var role = Admin.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role))?.Value;
            return Crypto.Decrypt(role);
        }

        #endregion Get current admin's data using Token

        #region Validate Admins

        protected void ValidateAdmin(Admin admin = null)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (admin == null)
                    admin = GetAdminAsync(User);
            }
            if (admin == null)
                ErrorResponse();

            if (admin.Deleted == true)
                ErrorResponse("Admin is deleted");

            if (admin.Active == false)
                ErrorResponse("Admin is inactive");

            this.Admin = admin;
        }

        //private Admin GetAdminAsync(Admin admin)
        //{
        //    throw new NotImplementedException();
        //}

        protected Admin GetAdminAsync(ClaimsPrincipal Admin)
        {
            var admin_id = GetAdminId(Admin).ToString();
            return DbContext.Admin.FirstOrDefault(x => x.Id.ToString().Equals(admin_id));
        }
        #endregion Validate Admin

        
    }
}
