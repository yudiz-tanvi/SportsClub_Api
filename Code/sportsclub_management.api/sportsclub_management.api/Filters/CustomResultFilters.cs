﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sportsclub_management.api.Filters
{
	public class CustomResultFilters : JsonResult
	{
		public CustomResultFilters(string message, int statusCode) : base(new CustomError(message, statusCode))
		{ 
			StatusCode = statusCode;
		}
	}

    public class CustomError
    {
        public dynamic Meta { get; set; }

        public CustomError(string message, int statusCode)
        {
            var finalMessage = message.Split("; ");

            Meta = new { message = finalMessage, statusCode };
        }
    }

    public class CustomResult
    {
        public dynamic Meta { get; set; }
        public dynamic Data { get; set; }

        public CustomResult(object data, int statusCode)
        {
            Meta = new { StatusCode = statusCode };
            Data = new { Data = data };
        }
    }
}
