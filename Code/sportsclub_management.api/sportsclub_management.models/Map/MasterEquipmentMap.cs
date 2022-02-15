using sportsclub_management.models.Requests.MasterEquipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Map
{
	public class MasterEquipmentMap
	{
        public MasterEquipment Map(MasterEquipmentUpdateRequest request)
        {
            return new MasterEquipment
            {
                Id = request.Id,
                Name = request.Name,
                Quantity = request.Quantity,
                Modified = System.DateTime.Now
            };
        }
    }
}
