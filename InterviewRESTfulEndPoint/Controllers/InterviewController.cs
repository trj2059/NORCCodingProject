using InterviewRESTfulEndPoint.Infrastructure.BasicAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewRESTfulEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        public InterviewController()
        {

        }

        // GET: api/<InterviewController>
        /// <summary>
        /// Gets all interviews
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [BasicAuth]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InterviewController>/5
        /// <summary>
        /// Gets a specific interview based off the interview id number
        /// </summary>
        /// <param name="id">The interview id</param>
        /// <returns>the interview object</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InterviewController>
        /// <summary>
        /// used to upload the interview
        /// </summary>
        /// <param name="value">a new interview</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InterviewController>/5
        /// <summary>
        /// udpate a given interview with a new value
        /// </summary>
        /// <param name="id">The id of a given interview</param>
        /// <param name="value">the new interview</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterviewController>/5
        /// <summary>
        /// delete's a given interview from the system.
        /// </summary>
        /// <param name="id">The ID of the interview</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
