using sportsclub_management.models.Requests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Requests.MasterCoach
{
	public class MasterCoachListRequest : BaseListRequest
	{
		public String Search_By_Name { get; set; }

		public String Search_By_AadharNumber { get; set; }
	}
}
