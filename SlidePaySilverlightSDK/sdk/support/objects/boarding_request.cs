using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class boarding_request
    {
        #region Cube-Variables

        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public int? user_master_id { get; set; }

        #endregion

        #region Variables-Passed-to-Application-via-Querystring

        public string device_type { get; set; }
        public string source_ip { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        #endregion

        #region Application-Variables

        public string applicant_email_address { get; set; }
        public string application_type { get; set; }
        public string business_name { get; set; }
        public string business_legal_name { get; set; }
        public string business_dba_name { get; set; }
        public string type_of_entity { get; set; }
        public string business_url { get; set; }
        public string business_address_1 { get; set; }
        public string business_address_2 { get; set; }
        public string business_city { get; set; }
        public string business_state { get; set; }
        public string business_zip { get; set; }
        public string business_phone { get; set; }
        public string home_address_1 { get; set; }
        public string home_address_2 { get; set; }
        public string home_city { get; set; }
        public string home_state { get; set; }
        public string home_zip { get; set; }
        public string home_phone { get; set; }
        public string applicant_first_name { get; set; }
        public string applicant_last_name { get; set; }
        public string date_of_birth { get; set; }
        public string social_security_number { get; set; }
        
        #endregion 
    }
}
