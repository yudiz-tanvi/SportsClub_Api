using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api_SportsClub.models
{
	public class BaseEntity : BaseIdEntity
	{
		[Required]
		public bool Active { get; set; }

		[Required]
		public bool Deleted { get; set; }

		[Required]
		public DateTime Created { get; set; }

		[Required]
		public DateTime Modified { get; set; }

		public BaseEntity()
		{

			Active = true;

			Deleted = false;

			Created = DateTime.Now;

			Modified = DateTime.Now;
		}
	}
}
