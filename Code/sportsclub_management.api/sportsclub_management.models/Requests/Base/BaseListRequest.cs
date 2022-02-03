using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Requests.Base
{
	public class BaseListRequest : BasePaginationRequest
	{
		public string SearchParam { get; set; }

		public string OrderBy { get; set; }
	}
}
