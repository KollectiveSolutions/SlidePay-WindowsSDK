using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public class payment
    {
        public int? payment_id { get; set; }
        public int? order_master_id { get; set; }
        public int? company_id { get; set; }
        public int? location_id { get; set; }
        public int? customer_id { get; set; } // NULLABLE
        public int? user_master_id { get; set; }
        public int? auto_capture { get; set; } // NULLABLE
        public string device_type { get; set; } // NULLABLE
        public string method { get; set; }
        public string method_other { get; set; } // NULLABLE
        public string stored_payment_guid { get; set; } // NULLABLE
        public string cc_type { get; set; } // NULLABLE
        public int? cc_present { get; set; } // NULLABLE
        public string cc_number { get; set; } // NULLABLE
        public string cc_expiry_month { get; set; } // NULLABLE
        public string cc_expiry_year { get; set; } // NULLABLE
        public string cc_name_on_card { get; set; } // NULLABLE
        public string cc_address_1 { get; set; } // NULLABLE
        public string cc_address_2 { get; set; } // NULLABLE
        public string cc_address_3 { get; set; } // NULLABLE
        public string cc_city { get; set; } // NULLABLE
        public string cc_state { get; set; } // NULLABLE
        public string cc_billing_zip { get; set; } // NULLABLE
        public string cc_country { get; set; } // NULLABLE
        public string cc_track1data { get; set; } // NULLABLE
        public string cc_track2data { get; set; } // NULLABLE
        public string cc_cvv2 { get; set; } // NULLABLE
        public string cc_redacted_number { get; set; } // NULLABLE
        public string encryption_vendor { get; set; } // NULLABLE
        public string encryption_ksn { get; set; } // NULLABLE
        public string encryption_device_serial { get; set; } // NULLABLE
        public decimal? amount { get; set; }
        public decimal? tip_amount { get; set; } // NULLABLE
        public int? is_refund { get; set; } // NULLABLE
        public int? refund_payment_id { get; set; } // NULLABLE
        public int? is_chargeback { get; set; } // NULLABLE
        public int? under_review { get; set; } // NULLABLE
        public string notes { get; set; } // NULLABLE
        public int? signature_cloud_object_id { get; set; } // NULLABLE
        public string provider { get; set; } // NULLABLE
        public string provider_payment_token { get; set; } // NULLABLE
        public string provider_transaction_token { get; set; } // NULLABLE
        public string provider_is_approved { get; set; } // NULLABLE
        public string provider_status_code { get; set; } // NULLABLE
        public string provider_status_message { get; set; } // NULLABLE
        public string provider_transaction_state { get; set; } // NULLABLE
        public string provider_approval_code { get; set; } // NULLABLE
        public string provider_capture_state { get; set; } // NULLABLE
        public string provider_capture_status_message { get; set; } // NULLABLE
        public string settlement_transaction_token { get; set; } // NULLABLE
        public decimal? provider_fee_amount { get; set; } // NULLABLE
        public string vendor_id { get; set; } // NULLABLE
        public decimal? vendor_markup_percent { get; set; } // NULLABLE
        public decimal? vendor_markup_pertrans { get; set; } // NULLABLE
        public decimal? fee_percentage { get; set; } // NULLABLE
        public decimal? fee_percentage_amount { get; set; } // NULLABLE
        public decimal? fee_per_transaction { get; set; } // NULLABLE
        public decimal? fee_interchange { get; set; } // NULLABLE
        public decimal? fee_total { get; set; } // NULLABLE
        public string ip_address { get; set; } // NULLABLE
        public string latitude { get; set; } // NULLABLE
        public string longitude { get; set; } // NULLABLE
        public string country { get; set; } // NULLABLE
        public decimal? distance_from_location { get; set; } // NULLABLE
        public decimal? processor_time_ms { get; set; } // NULLABLE
        public decimal? total_time_ms { get; set; } // NULLABLE
        public DateTime? capture_requested { get; set; } // NULLABLE
        public DateTime? capture_confirmed { get; set; } // NULLABLE
        public DateTime? created { get; set; } // NULLABLE
        public DateTime? last_update { get; set; } // NULLABLE
    }
}
