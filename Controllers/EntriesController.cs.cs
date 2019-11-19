using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using needle_tracker.Models;

namespace entries_tracker.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EntriessController : ControllerBase
	{
		// GET api/entries
		[HttpGet]
		public ActionResult<IEnumerable<Entry>> Get()
		{

		}

		// GET api/entries/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "entries";
		}

		// POST api/entries
		[HttpPost]
		public void Post([FromBody] string entries)
		{
		}

		// PUT api/entries/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string entries)
		{
		}

		// DELETE api/entries/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
