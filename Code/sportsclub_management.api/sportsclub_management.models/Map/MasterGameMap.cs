using sportsclub_management.models.Requests.MasterGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class MasterGameMap
	{
        public MasterGame Map(MasterGameUpdateRequest request)
        {
            return new MasterGame
            {
                Id = request.Id,
                Name = request.Name,
                Modified = System.DateTime.Now
            };
        }
    }
}
