using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InterviewRESTfulEndPoint.Models
{
    public class InterviewResponse
    {
        [Key]
        public int ID { get; set; }
        public int InterviewID { get; set; } // two way link
        public Guid? guid { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
