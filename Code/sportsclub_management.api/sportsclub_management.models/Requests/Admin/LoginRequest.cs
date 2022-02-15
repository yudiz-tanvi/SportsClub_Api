using sportsclub_management.models.Requests.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Admin
{
	public class LoginRequest : BasePasswordRequest
	{
		[Required]
		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid Email")]

		public string Email { get; set; }
	}
}
