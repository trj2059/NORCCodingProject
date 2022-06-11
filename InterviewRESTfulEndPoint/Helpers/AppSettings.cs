using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewRESTfulEndPoint.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Pepper { get; set; }
        public int NumberOfDaysUntilJWTTokenExpires { get; set; }
    }
}
