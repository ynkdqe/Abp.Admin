using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class LoginResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public object User { get; set; }
        public List<string> Permissions { get; set; }
    }
}
