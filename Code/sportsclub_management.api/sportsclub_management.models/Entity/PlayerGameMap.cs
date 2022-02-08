using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class PlayerGameMap : BaseEntity
	{
		[Required]
		public Guid MasterPlayerId { get; set; }
		[ForeignKey("MasterPlayerId")]
		public MasterPlayer MasterPlayer { get; set; }

		[Required]
		public Guid MasterGameId { get; set; }
		[ForeignKey("MasterGameId")]
		public MasterGame MasterGame { get; set; }
	}
}
