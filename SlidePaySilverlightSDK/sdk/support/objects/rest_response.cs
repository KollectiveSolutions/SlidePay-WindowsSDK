using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class rest_response
    {
        public string encoding { get; set; }
        public string content_type { get; set; }
        public long content_length { get; set; }
        public string response_uri { get; set; }
        public int status_code { get; set; }
        public string status_description { get; set; }
        public string output_body_string { get; set; }
    }
}
