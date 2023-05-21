using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class LoginResquest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
