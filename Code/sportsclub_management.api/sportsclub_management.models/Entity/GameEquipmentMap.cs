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

		[Required]
		public Guid MasterGameId { get; set; }
		[ForeignKey("MasterGameId")]
		public MasterGame MasterGame { get; set; }

		[Required]
		public Guid MasterEquipmentId { get; set; }
		[ForeignKey("MasterEquipmentId")]
		public MasterEquipment MasterEquipment { get; set; }

	}
}
