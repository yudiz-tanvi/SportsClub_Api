using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Feedback
{
	public class FeedbackUpdateRequest : FeedbackInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
