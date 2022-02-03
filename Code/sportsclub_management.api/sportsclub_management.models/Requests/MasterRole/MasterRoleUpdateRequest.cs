using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sportsclub_management.models.Requests.MasterRole
{
	public class MasterRoleUpdateRequest : MasterRoleInsertRequest
	{
		[Required]
		public Guid Id { get; set; }
	}
}
