using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class PlayerGameMap : BaseEntity
	{
		[ForeignKey("MasterPlayer")]
		public Guid MasterPlayerId { get; set; }
		public MasterPlayer MasterPlayer { get; set; }

		[ForeignKey("MasterGame")]
		public Guid MasterGameId { get; set; }
		public MasterGame MasterGame { get; set; }
	}
}
