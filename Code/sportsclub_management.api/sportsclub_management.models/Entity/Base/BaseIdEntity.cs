using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models
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
