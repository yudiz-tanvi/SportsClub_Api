using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Base.MasterPlayer
{
	public class MasterPlayerInsertRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public long Mobile { get; set; }

		[Required]
		public string AadharNumber { get; set; }

		[Required]
		public Decimal Fees { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public DateTime JoiningDate { get; set; }
	}
}
