using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class CoachAdress : BaseEntity
	{
		[Required]
		[MaxLength(500)]
		public string Coach_Adress { get; set; }

		[ForeignKey("MasterCoach")]
		public Guid MasterCoachId { get; set; }
		public MasterCoach MasterCoach { get; set; }
	}
}
