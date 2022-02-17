using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using sportsclub_management.api.Controllers.Base;
using sportsclub_management.api.Helpers;
using sportsclub_management.models;
using sportsclub_management.models.Configs;
using sportsclub_management.models.Constants;
using sportsclub_management.models.Map;
using sportsclub_management.models.Requests.Admin;
using sportsclub_management.models.Requests.Base;
using sportsclub_management.models.Response;
using sportsclub_management.repository;
using sportsclub_management.security;
using sportsclub_management.security.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Controllers
{
	public class AdminController : BaseController
	{
        public AdminController(SportsClubManagementContext DbContext, ICrypto Crypto) : base(DbContext , Crypto)  //TODO: Explain Depedency Injection
        {
        }

        #region Admin Login
        [AllowAnonymous, HttpPost(ActionConts.Login)]
        public IActionResult LoginAsync(
            [FromBody] LoginRequest request,
            [FromServices] IOptions<AuthConfigs> AuthConfigOptions)
        {
            if (request == null) request = new LoginRequest();

            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            request.Password = Crypto.EncryptPassword(request.Password);
            var dbResponse = DbContext.Admin.FirstOrDefault(x =>
                           x.Email.Equals(request.Email.Trim()) &&
                           x.Password.Equals(request.Password.Trim()));

            if (dbResponse is null) return ErrorResponse();

            ValidateAdmin(dbResponse);

            var response = new LoginResponse
            {
                Id = dbResponse.Id,
                Name = dbResponse.Name,
                Username = dbResponse.Username,
                Email = dbResponse.Email,
                Mobile = dbResponse.Mobile,
                Created = dbResponse.Created,
                Modified = dbResponse.Modified,
            };

            response.Token = new TokenHelpers(Crypto).GetAccessToken(AuthConfigOptions.Value, response);
            return OkResponse(response);

        }
        #endregion Admin Login

        //IRepository<ApiDemoContext, CountryEntity> CountryRepository;

        [HttpPost(ActionConts.AdminSelectList)]
        public IActionResult AdminList([FromBody] BaseListRequest request)
        {
            if (request == null) request = new BaseListRequest(); // TODO: Explain the usage

            var response = DbContext.Admin
                            //.Where(x=>(!string.IsNullOrEmpty(request.SearchParam) && x.Name.Contains(request.SearchParam)))  // Search
                            .Where(x => !x.Deleted)
                            .Skip(request.PageNo * request.PageSize) // Skip records     
                            .Take(request.PageSize); // How many records select in page


            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminSelectById)]
        public IActionResult AdminSelectById([FromBody] BaseRequiredIdRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var response = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminSelectForDropdown)]
        public IActionResult AdminSelectForDropdown()
        {
            var response = DbContext.Admin
                .Where(x => !x.Deleted && x.Active)
                .Select(x => new { x.Name, x.Id });

            return OkResponse(response);
        }

        [HttpPost(ActionConts.AdminInsert)]
        public async Task<IActionResult> AdminInsert([FromBody] AdminInsertRequest request)
        {

			try
			{
				if (!ModelState.IsValid)
					return ErrorResponse(ModelState);

				if (DbContext.Admin.Any(x => x.Name.Equals(request.Name)))
					return ErrorResponse("Admin Already Exists");

				await DbContext.Admin.AddAsync(new Admin
				{
					Name = request.Name,
					Email = request.Email,
					Password = Crypto.EncryptPassword(request.Password),
					Username = request.Username,
					Mobile = request.Mobile,
					Gender = request.Gender,
					MasterRoleId = request.MasterRoleId,
				});
				DbContext.SaveChanges();

				return OkResponse();
			}
			catch (Exception ex)
			{

                return ErrorResponse(ex.Message);
			}
        }

        /*[HttpPost(ActionConts.AdminInsert)]
        public async Task<IActionResult> AdminInsert([FromBody] AdminInsertRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            if (DbContext.Admin.Any(x => x.Name.Equals(request.Name)))
                return ErrorResponse("Name Already Exists");

            await DbContext.Admin.AddAsync(new Admin
            {
                Name = request.Name,
                Email = request.Email,
                Password = Crypto.EncryptPassword(request.Password),
                Username = request.Username,
                Mobile = request.Mobile,
                Gender = request.Gender,
                MasterRoleId = request.MasterRoleId,
            });
            DbContext.SaveChanges();

            return OkResponse();
        }*/

        [HttpPost(ActionConts.AdminUpdate)]
        public async Task<IActionResult> AdminUpdateAsync([FromBody] AdminUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return ErrorResponse(ModelState);

            var admin = new AdminMap().Map(request);

            DbContext.Admin.Update(admin);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.AdminDelete)]
        public async Task<IActionResult> AdminDelete([FromBody] BaseIdRequest request)
        {
            var Admin = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            DbContext.Admin.Remove(Admin);
            DbContext.SaveChanges();

            return OkResponse();
        }

        [HttpPost(ActionConts.AdminSoftDelete)]
        public async Task<IActionResult> AdminSoftDelete([FromBody] BaseIdRequest request)
        {
            var Admin = DbContext.Admin.FirstOrDefault(x => x.Id.Equals(request.Id));

            if (Admin.Deleted == false)
            {
                Admin.Deleted = true;
            }

            DbContext.SaveChanges();

            return OkResponse();
        }
    }
}
