using sportsclub_management.models.Requests.MasterCoach;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class MasterCoachMap
	{
        public MasterCoach Map(MasterCoachUpdateRequest request)
        {
            return new MasterCoach
            {
                Id = request.Id,
                Name = request.Name,
                Mobile = request.Mobile,
                AadharNumber = request.AadharNumber,
                MasterGameId = request.MasterGameId,
                Modified = System.DateTime.Now
            };
        }
    }
}
