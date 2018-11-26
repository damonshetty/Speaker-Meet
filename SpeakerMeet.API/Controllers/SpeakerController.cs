using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.Services.Interfaces;
using SpeakerMeet.DTO;

namespace SpeakerMeet.API.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [Route("search")]
        public IActionResult Search(string searchString)
        {
            var hardCodedSpeakers = new List<Speaker>
            {
                new Speaker {Name = "Josh"},
                new Speaker {Name = "Joshua"},
                new Speaker {Name = "Joseph"},
                new Speaker {Name = "Bill"},
            };

            _speakerService.Search("foo");

            var speakers = hardCodedSpeakers
    .Where(x => x.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(speakers);
        }
    }

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
    

}
