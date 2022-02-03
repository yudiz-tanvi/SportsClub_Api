using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterRole
{
	public class MasterRoleInsertRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Display_Name { get; set; }
	}
}
