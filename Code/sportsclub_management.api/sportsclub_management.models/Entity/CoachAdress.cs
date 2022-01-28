using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models
{
	public class CoachAdress : BaseEntity
	{
		[Required]
		[MaxLength(500)]
		public string Coach_Adress { get; set; }
	}
}
