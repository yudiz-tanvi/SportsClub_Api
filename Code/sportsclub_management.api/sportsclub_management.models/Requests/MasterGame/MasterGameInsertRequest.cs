using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterGame
{
	public class MasterGameInsertRequest
	{
		[Required]
		public string Name { get; set; }
	}
}
