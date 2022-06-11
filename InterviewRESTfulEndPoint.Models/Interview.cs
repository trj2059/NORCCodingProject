using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InterviewRESTfulEndPoint.Models
{
    /// <summary>
    /// Model for representing each individual interview.
    /// </summary>
    public class Interview
    {
        [Key]
        public int ID { get; set; }
        public Interviewee Interviewee { get; set; }
        public List<InterviewResponse> InterviewResponses { get; set; }
        public Guid? guid { get; set; } 
        public DateTime DateTimeOfInterview { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
