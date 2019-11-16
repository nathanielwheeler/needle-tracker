using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace needle_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeedlesController : ControllerBase
    {
        // GET api/needles
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "needle1", "needle2" };
        }

        // GET api/needles/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "needle";
        }

        // POST api/needles
        [HttpPost]
        public void Post([FromBody] string needle)
        {
        }

        // PUT api/needles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string needle)
        {
        }

        // DELETE api/needles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
