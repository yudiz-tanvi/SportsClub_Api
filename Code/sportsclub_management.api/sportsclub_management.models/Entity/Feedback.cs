using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api_SportsClub.models
{
	public class Feedback : BaseEntity
	{
		[Required]
		[MaxLength(500)]
		public string Add_Feedback { get; set; }
	}
}
