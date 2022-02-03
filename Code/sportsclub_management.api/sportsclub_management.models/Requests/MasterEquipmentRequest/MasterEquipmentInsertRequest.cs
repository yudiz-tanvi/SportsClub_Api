using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterEquipmentRequest
{
	public class MasterEquipmentInsertRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public long Quantity { get; set; }
	}
}
