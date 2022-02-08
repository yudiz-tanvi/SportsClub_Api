using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Admin
{
	public class AdminInsertRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public long Mobile { get; set; }

		[Required]
		public string Gender { get; set; }

		[Required]
		public Guid MasterRoleId { get; set; }
	}
}
