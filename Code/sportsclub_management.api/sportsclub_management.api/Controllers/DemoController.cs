using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_SportsClub.api.Controllers
{
	[Route("api/first_api")]
	[ApiController]
	public class DemoController : ControllerBase
	{
		public IActionResult Demo(int a , int b)
		{
			return Ok("Addition Of Two Numbers :" + (a + b));	
		}
	}
}
