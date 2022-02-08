using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.Feedback
{
	public class FeedbackInsertRequest
	{
		[Required]
		public string Add_Feedback { get; set; }

		[Required]
		public Guid MasterPlayerId { get; set; }

		[Required]
		public Guid MasterGameId { get; set; }
	}
}
