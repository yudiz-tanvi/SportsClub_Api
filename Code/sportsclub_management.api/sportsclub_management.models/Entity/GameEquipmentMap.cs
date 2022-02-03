using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class GameEquipmentMap : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public long Quantity { get; set; }

		[Required]
		[MaxLength(250)]
		public string Remarks { get; set; }

		[ForeignKey("MasterGame")]
		public Guid MasterGameId { get; set; }
		public MasterGame MasterGame { get; set; }

		[ForeignKey("MasterEquipment")]
		public Guid MasterEquipmentId { get; set; }
		public MasterEquipment MasterEquipment { get; set; }

	}
}
