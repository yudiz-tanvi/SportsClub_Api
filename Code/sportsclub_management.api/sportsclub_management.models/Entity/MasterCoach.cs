using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api_SportsClub.models
{
	public class MasterCoach : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		public string Name
		{
			get; set;
		}

		[Required]
		[MaxLength(10)]
		public int Mobile
		{
			get; set;
		}

		[Required]
		[MaxLength(12)]
		public string AadharNumber
		{
			get; set;
		}



	}
}
