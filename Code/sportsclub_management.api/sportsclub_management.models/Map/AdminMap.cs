using sportsclub_management.models.Requests.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class AdminMap
	{
        public Admin Map(AdminUpdateRequest request)
        {
            return new Admin
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Username = request.Username,
                Mobile = request.Mobile,
                Gender = request.Gender,
                MasterRoleId = request.MasterRoleId,
                Modified = System.DateTime.Now
            };
        }
    }
}
