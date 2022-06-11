using InterviewRESTfulEndPoint.Infrastructure.BasicAuth;
using InterviewRESTfulEndPoint.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using InterviewRESTfulEndPoint.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewRESTfulEndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewRepositoryService _interviewRepositoryService;
        private readonly ILogger _logger;

        public InterviewController(ILogger<InterviewController> logger, IInterviewRepositoryService interviewRepositoryService)
        {
            _logger = logger;
            _interviewRepositoryService = interviewRepositoryService;
        }

        // GET: api/<InterviewController>
        /// <summary>
        /// Gets a range of interviews
        /// </summary>
        /// <returns>a list of interviews</returns>
        [HttpGet("{start}/{range}")]
        [BasicAuth]
        public IEnumerable<Interview> Get(int start,int range)
        {
            try
            {
                return _interviewRepositoryService.GetRange(start, range);
            } 
            catch(Exception ex)
            {
                _logger.LogError("Error in InterviewController.  Exception message:" + ex.Message);
                return null;
            }
        }

        // GET api/<InterviewController>/5
        /// <summary>
        /// Gets a specific interview based off the interview id number
        /// </summary>
        /// <param name="id">The interview id</param>
        /// <returns>the interview object</returns>
        [HttpGet("{id}")]
        [BasicAuth]
        public Interview Get(int id)
        {
            try
            {
                return _interviewRepositoryService.GetInterview(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in InterviewController.  Exception message:" + ex.Message);
                return null;
            }
        }

        // POST api/<InterviewController>
        /// <summary>
        /// used to upload the interview
        /// </summary>
        /// <param name="value">a new interview</param>
        [HttpPost]
        [BasicAuth]
        public void Post([FromBody] Interview interview)
        {
            try
            {
                _interviewRepositoryService.AddAnInterview(interview);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in InterviewController.  Exception message:" + ex.Message);
            }
        }

        // PUT api/<InterviewController>/5
        /// <summary>
        /// udpate a given interview with a new value
        /// </summary>
        /// <param name="id">The id of a given interview</param>
        /// <param name="value">the new interview</param>
        [HttpPut("{id}")]
        [BasicAuth]
        public void Put(int id, [FromBody] Interview interview)
        {
        }

        // DELETE api/<InterviewController>/5
        /// <summary>
        /// delete's a given interview from the system.
        /// </summary>
        /// <param name="id">The ID of the interview</param>
        [HttpDelete("{id}")]
        [BasicAuth]
        public void Delete(int id)
        {
        }
    }
}
