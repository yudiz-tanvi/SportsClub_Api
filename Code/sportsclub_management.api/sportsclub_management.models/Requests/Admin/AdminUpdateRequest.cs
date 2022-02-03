using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Admin
{
	public class AdminUpdateRequest : AdminInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
