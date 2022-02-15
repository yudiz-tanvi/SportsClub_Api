using sportsclub_management.models.Requests.MasterRole;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class MasterRoleMap
	{
        public MasterRole Map(MasterRoleUpdateRequest request)
        {
            return new MasterRole
            {
                Id = request.Id,
                Name = request.Name,
                Display_Name = request.Display_Name,
                Modified = System.DateTime.Now
            };
        }
    }
}
