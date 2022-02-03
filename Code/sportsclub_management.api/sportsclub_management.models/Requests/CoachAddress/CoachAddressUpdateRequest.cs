using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.CoachAddress
{
	public class CoachAddressUpdateRequest : CoachAddressInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
