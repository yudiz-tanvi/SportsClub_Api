using sportsclub_management.models.Requests.MasterPlayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class MasterPlayerMap
	{
        public MasterPlayer Map(MasterPlayerUpdateRequest request)
        {
            return new MasterPlayer
            {
                Id = request.Id,
                Name = request.Name,
                Mobile = request.Mobile,
                AadharNumber = request.AadharNumber,
                Fees = request.Fees,
                Email = request.Email,
                JoiningDate = DateTime.Now,
                Modified = System.DateTime.Now
            };
        }
    }
}
