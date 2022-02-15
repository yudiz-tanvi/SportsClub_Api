using sportsclub_management.models.Requests.PlayerGameMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class PlayerGameMapMap
	{
        public PlayerGameMap Map(PlayerGameMapUpdateRequest request)
        {
            return new PlayerGameMap
            {
                Id = request.Id,
                MasterPlayerId = request.MasterPlayerId,
                MasterGameId = request.MasterGameId,
                Modified = System.DateTime.Now
            };
        }
    }
}
