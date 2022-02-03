using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class CoachAddress : BaseEntity
	{
		[Required]
		[MaxLength(500)]
		public string Coach_Address { get; set; }

		[ForeignKey("MasterCoach")]
		public Guid MasterCoachId { get; set; }
		public MasterCoach MasterCoach { get; set; }
	}
}
