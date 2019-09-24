using System;
using System.Collections.Generic;
using System.Text;

namespace SuporteCore.Entity.DTO
{
    public class PhoebusDTO : BaseDTO
    {
        public string Nsu { get; set; }
        public string Card_number { get; set; }
        public string Terminal { get; set; }
        public string Confirmation_date { get; set; }
        public DateTime? Date_base { get; set; }
        public int PhoebusId { get; set; }
        public string Acquirer_nsu { get; set; }
        public string value { get; set; }
        public string Status { get; set; }
        public string Parcels { get; set; }
        public string Brand { get; set; }
        public string Start_date { get; set; }
        public string Finish_date { get; set; }
        public string Payment_date { get; set; }
        public string Response_code { get; set; }
        public string Authorization_number { get; set; }
        public string Tef_terminal { get; set; }
        public string Terminal_serial_number { get; set; }
        public string Terminal_manufacturer { get; set; }
        public string Terminal_model { get; set; }
        public string Terminal_type { get; set; }
        public string Acquirer { get; set; }
        public string Merchant { get; set; }
        public string Tef_merchant { get; set; }
        public string Merchant_category_code { get; set; }
        public string Merchant_national_type { get; set; }
        public string Merchant_national_id { get; set; }
        public string Product_name { get; set; }
        public string Product_id { get; set; }
        public string Card_input_method { get; set; }
        public string Requested_password { get; set; }
        public string Fallback { get; set; }
        public string Origin { get; set; }
        public string Authorization_time { get; set; }
        public string Client_version { get; set; }
        public string Server_version { get; set; }
        public string Original_nsu { get; set; }
        public string Original_date { get; set; }
        public string Card_holder { get; set; }
        public bool Status_Valido { get; set; }
    }
}
