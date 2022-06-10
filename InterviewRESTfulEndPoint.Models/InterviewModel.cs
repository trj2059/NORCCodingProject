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
    public class InterviewModel
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string InterviewerName { get; set; }
        [StringLength(200)]
        public string IntervieweeName { get; set; }

        public DateTime DateTimeOfInterview { get; set; }

    }
}
