using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models
{
	public class GameEquipmentMap : BaseEntity
	{
		[Required]
		[MaxLength(100)]
		public string Quantity { get; set; }

		[Required]
		[MaxLength(250)]
		public string Remarks { get; set; }
	}
}
