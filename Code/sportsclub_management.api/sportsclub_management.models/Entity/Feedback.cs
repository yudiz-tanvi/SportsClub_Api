using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class Feedback : BaseEntity
	{
		[Required]
		[MaxLength(500)]
		public string Add_Feedback { get; set; }

		[ForeignKey("MaasterPlayer")]
		public Guid MasterPlayerId { get; set; }
		public MasterPlayer MasterPlayer { get; set; }

		[ForeignKey("MasterGame")]
		public Guid MasterGameId { get; set; }
		public MasterGame MasterGame { get; set; }
	}
}
