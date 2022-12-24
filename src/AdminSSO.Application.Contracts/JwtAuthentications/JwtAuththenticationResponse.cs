using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.JwtAuthentications
{
    public class JwtAuththenticationResponse
    {
        public string token { get; set; }
        public string user_name { set; get; }
        public int expires_in { get; set; }
    }
}
