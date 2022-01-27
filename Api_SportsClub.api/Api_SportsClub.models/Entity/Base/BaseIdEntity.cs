using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api_SportsClub.models
{
	public class BaseIdEntity
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		public BaseIdEntity()
		{
			Id = Guid.NewGuid();
		}
	}
}
