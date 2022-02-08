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

		[Required]
		public Guid MasterPlayerId { get; set; }
		[ForeignKey("MaasterPlayerId")]
		public MasterPlayer MasterPlayer { get; set; }

		[Required]
		public Guid MasterGameId { get; set; }
		[ForeignKey("MasterGameId")]
		public MasterGame MasterGame { get; set; }
	}
}
