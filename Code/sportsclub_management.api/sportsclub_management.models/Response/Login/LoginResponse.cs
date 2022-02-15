using System;
using System.Collections.Generic;
using System.Text;

namespace sportsclub_management.models.Response
{
	public class LoginResponse
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        //public string Role { get; set; }

        public string Token { get; set; }

        public string UniqueId { get; set; } = Guid.NewGuid().ToString();
    }
}
