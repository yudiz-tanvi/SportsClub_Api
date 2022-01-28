using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class Admin : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[MaxLength(25)]
		public string Email { get; set; }

		[Required]
		[MaxLength(20)]
		public string Password { get; set; }

		[Required]
		[MaxLength(25)]
		public string Username { get; set; }

		[Required]
		[MaxLength(10)]
		public int Mobile { get; set; }

		[Required]
		[MaxLength(10)]
		public string Gender { get; set; }

		[ForeignKey("MasterRole")]
		public Guid MasterRoleId { get; set; }
		public MasterRole MasterRole { get; set; }
	}
}
