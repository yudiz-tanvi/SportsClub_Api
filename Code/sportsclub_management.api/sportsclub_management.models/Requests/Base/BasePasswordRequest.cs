using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Base
{
	public class BasePasswordRequest
	{
		[Required]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Invalid Password Format")]
		[StringLength(128, ErrorMessage = "The {0} must be at least {2} character long.", MinimumLength = 8)]

		public string Password { get; set; }
	}
}
