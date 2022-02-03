using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterCoach
{
	public class MasterCoachInsertRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public long Mobile { get; set; }

		[Required]
		public string AadharNumber { get; set; }


	}
}
