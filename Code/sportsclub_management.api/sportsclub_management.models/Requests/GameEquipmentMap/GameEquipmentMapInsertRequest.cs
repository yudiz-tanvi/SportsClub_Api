using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.GameEquipmentMap
{
	public class GameEquipmentMapInsertRequest
	{
		[Required]
		public long Quantity { get; set; }

		[Required]
		public string Remarks { get; set; }

		[Required]
		public Guid MasterGameId { get; set; }

		[Required]
		public Guid MasterEquipmentId { get; set; }
	}
}
