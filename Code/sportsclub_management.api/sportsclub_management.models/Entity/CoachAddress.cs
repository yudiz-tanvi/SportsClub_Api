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
		public string Address { get; set; }

		[Required]
		public Guid MasterCoachId { get; set; }
		[ForeignKey("MasterCoachId")]
		public MasterCoach MasterCoach { get; set; }
	}
}
