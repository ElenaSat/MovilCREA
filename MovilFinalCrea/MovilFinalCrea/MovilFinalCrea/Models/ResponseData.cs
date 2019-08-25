using System;
using System.Collections.Generic;
using System.Text;

namespace MovilFinalCrea.Models
{
    public class ResponseData: ResponseDefault
    {
        public clsUsers data { get; set; }
    }

    public class ResponseDefault {

        public int success { get; set; }
        public int responseCode { get; set; }
        public string message { get; set; }

    }
}
