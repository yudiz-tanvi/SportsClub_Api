using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.GameEquipmentMap
{
	public class GameEquipmentMapUpdateRequest : GameEquipmentMapInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
