using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.CoachAddress
{
	public class CoachAddressInsertRequest
	{
		[Required]
		public string Address { get; set; }

		[Required]
		public Guid MasterCoachId { get; set; }
	}
}
