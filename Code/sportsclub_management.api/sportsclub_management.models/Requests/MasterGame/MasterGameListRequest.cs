using sportsclub_management.models.Requests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Requests.MasterGame
{
	public class MasterGameListRequest : BaseListRequest
	{
		public String Name { get; set; }
	}
}
