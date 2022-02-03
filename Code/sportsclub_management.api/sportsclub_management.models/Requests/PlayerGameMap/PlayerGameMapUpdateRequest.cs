using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.PlayerGameMap
{
	public class PlayerGameMapUpdateRequest : PlayerGameMapInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
