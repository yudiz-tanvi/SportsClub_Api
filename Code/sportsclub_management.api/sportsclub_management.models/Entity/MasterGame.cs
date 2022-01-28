using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models
{
	public class MasterGame : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }
	}
}
