using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpeakerMeet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    
    public class SpeakerController : Controller
    {
        public IActionResult Search(string searchString)
        {
            var hardCodedSpeakers = new List<Speaker>
            {
                new Speaker {Name = "Josh"},
                new Speaker {Name = "Joshua"},
                new Speaker {Name = "Joseph"},
                new Speaker {Name = "Bill"},
            };

            var speakers = hardCodedSpeakers
    .Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(speakers);
        }
    }

    public class Speaker
    {
        public string Name { get; set; }
    }
}
