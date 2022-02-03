using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterGame
{
	public class MasterGameUpdateRequest :MasterGameInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
