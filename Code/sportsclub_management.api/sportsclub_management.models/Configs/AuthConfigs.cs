using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Configs
{
	public class AuthConfigs
	{
		public string Key { get; set; }

		public string Issuer { get; set; }

		public string Audiance { get; set; }

		public int AccessExpireDays { get; set; }
	}
}
