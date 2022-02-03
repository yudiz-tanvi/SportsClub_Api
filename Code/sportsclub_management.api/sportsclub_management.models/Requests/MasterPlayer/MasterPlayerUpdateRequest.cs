using sportsclub_management.models.Requests.Base.MasterPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterPlayer
{
	public class MasterPlayerUpdateRequest : MasterPlayerInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
