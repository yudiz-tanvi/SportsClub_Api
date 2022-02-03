using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterEquipmentRequest
{
	public class MasterEquipmentUpdateRequest : MasterEquipmentInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
