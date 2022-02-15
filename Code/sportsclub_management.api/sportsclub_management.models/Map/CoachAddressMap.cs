using sportsclub_management.models.Requests.CoachAddress;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class CoachAddressMap
	{
        public CoachAddress Map(CoachAddressUpdateRequest request)
        {
            return new CoachAddress
            {
                Id = request.Id,
                Address = request.Address,
                MasterCoachId = request.MasterCoachId,
                Modified = System.DateTime.Now
            };
        }
    }
}
