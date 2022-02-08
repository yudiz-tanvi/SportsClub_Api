using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class MasterCoach : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name
		{
			get; set;
		}

		[Required]
		[MaxLength(10)]
		public long Mobile
		{
			get; set;
		}

		[Required]
		[MaxLength(12)]
		public string AadharNumber
		{
			get; set;
		}

		[Required]
		public Guid MasterGameId { get; set; }
		[ForeignKey("MasterGameId")]
		public MasterGame MasterGame { get; set; }

	}
}
