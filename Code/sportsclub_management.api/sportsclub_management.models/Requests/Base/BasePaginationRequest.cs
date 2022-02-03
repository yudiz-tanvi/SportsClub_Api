using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Requests.Base
{
	public class BasePaginationRequest
	{
		public int PageNo { get; set; }

		public int PageSize { get; set; }
	}
}
