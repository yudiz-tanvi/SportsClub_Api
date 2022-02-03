using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Base
{
	public class BaseIdRequest
	{
		public Guid Id { get; set; }
	}

	public class BaseRequiredIdRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
