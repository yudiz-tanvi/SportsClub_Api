using sportsclub_management.models.Requests.GameEquipmentMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class GameEquipmentMapMap
	{
        public GameEquipmentMap Map(GameEquipmentMapUpdateRequest request)
        {
            return new GameEquipmentMap
            {
                Id = request.Id,
                Quantity = request.Quantity,
                Remarks = request.Remarks,
                MasterGameId = request.MasterGameId,
                MasterEquipmentId = request.MasterEquipmentId,
                Modified = System.DateTime.Now
            };
        }
    }
}
