using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sportsclub_management.models
{
	public class MasterPlayer : BaseEntity
	{
		[Required]
		[MaxLength(50)]
		
		public string Name
		{
			get; set;
		}

		[Required]
		[MaxLength(10)]
		public long Mobile
		{
			get; set;
		}

		[Required]
		[MaxLength(12)]
		public string AadharNumber
		{
			get; set;
		}

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Fees
		{
			get; set;
		}

		[Required]
		[MaxLength(25)]
		public string Email
		{
			get; set;
		}

		[Required]
		public DateTime JoiningDate
		{
			get; set;
		}

		public ICollection<PlayerGameMap> PlayerGameMap { get; set; }

		public ICollection<Feedback> Feedback { get; set; }
	}
}
