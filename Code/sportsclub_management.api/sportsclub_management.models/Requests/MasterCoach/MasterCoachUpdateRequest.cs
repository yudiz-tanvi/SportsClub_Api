using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterCoach
{
	public class MasterCoachUpdateRequest : MasterCoachInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
