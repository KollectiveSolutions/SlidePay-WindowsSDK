using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class token
    {
        public DateTime created { get; set; }
        public string server_name { get; set; }
        public string endpoint { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string ip_address { get; set; }
        public string random { get; set; }
        public string timezone { get; set; }
        public int? company_id { get; set; }
        public string company_name { get; set; }
        public int? location_id { get; set; }
        public string location_name { get; set; }
        public int? user_master_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? is_clerk { get; set; }
        public int? is_locmgr { get; set; }
        public int? is_comgr { get; set; }
        public int? is_admin { get; set; }
        public int? is_isv { get; set; }
    }
}
