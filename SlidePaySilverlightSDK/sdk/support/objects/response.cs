using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class response
    {
        public bool success { get; set; }
        public string custom { get; set; }
        public string operation { get; set; }
        public string endpoint { get; set; }
        public string timezone { get; set; }
        public string method { get; set; }
        public string obj { get; set; }
        public int id { get; set; }
        public string milliseconds { get; set; }
        public object data { get; set; }
        public string data_md5 { get; set; }
    }
}
