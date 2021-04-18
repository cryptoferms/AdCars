using System;
using System.Collections.Generic;
using System.Text;

namespace AdCars.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public int creation_Time { get; set; }
        public int expiration_Time { get; set; }
        public int user_id { get; set; }
        public string user_nome { get; set; }
        public string user_email { get; set; }
    }
}
