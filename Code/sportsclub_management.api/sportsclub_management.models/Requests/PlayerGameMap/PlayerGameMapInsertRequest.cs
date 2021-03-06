using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.PlayerGameMap
{
	public class PlayerGameMapInsertRequest
	{
		[Required]
		public Guid MasterPlayerId { get; set; }

		[Required]
		public Guid  MasterGameId { get; set; }
	}
}
