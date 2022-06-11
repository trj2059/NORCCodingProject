using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewRESTfulEndPoint.Models
{
    public class Interviewer
    {
        [Key]
        public int ID { get; set; }
        public Guid? guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Interview> Interviews { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
