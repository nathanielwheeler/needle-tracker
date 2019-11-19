using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using needle_tracker.Models;
using needle_tracker.Services;

namespace entries_tracker.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EntriesController : ControllerBase
	{

		#region Controller Configuration
		private readonly EntriesService _es;
		private readonly AccountService _as;
		public EntriesController(EntriesService es, AccountService aServ)
		{
			_es = es;
			_as = aServ;
		}
		#endregion

		[Authorize]
		[HttpGet("undefined")]
		[HttpDelete("undefined")]
		public BadRequestObjectResult Undefined() { return BadRequest("Undefined Id"); }

		// GET api/entries
		[Authorize]
		[HttpGet]
		public ActionResult<IEnumerable<Entry>> Get()
		{
			try
			{
				return Ok(_es.Get());
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		// GET api/entries/5
		[Authorize]
		[HttpGet("{id}")]
		public ActionResult<Entry> Get(int id)
		{
			try
			{
				return Ok(_es.Get(id));
			}
			catch (Exception e) { return BadRequest(e.Message); }
		}

		// POST api/entries
		[Authorize]
		[HttpPost]
		public ActionResult<Entry> Post([FromBody] Entry newEntry)
		{
			try
			{
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				newEntry.UserId = user.Id;
				return Ok(_es.Post(newEntry));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		// PUT api/entries/5
		[Authorize]
		[HttpPut("{id}")]
		public ActionResult<Entry> Put([FromBody] Entry newEntry, int id)
		{
			try
			{
				newEntry.Id = id;
				string reqUserId = HttpContext.User.FindFirstValue("Id");
				User user = _as.GetUserById(reqUserId);
				return Ok(_es.Put(newEntry, user.Id));
			}
			catch (Exception e) { return BadRequest(e.Message); }

		}

		// DELETE api/entries/5
		[Authorize]
		[HttpDelete("{id}")]
		public ActionResult<string> Delete(int id)
		{
			string reqUserId = HttpContext.User.FindFirstValue("Id");
			User user = _as.GetUserById(reqUserId);
			return Ok(_es.Delete(id, user.Id));
		}
	}
}
