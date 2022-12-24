using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class UserInputUpdateDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }       
        public int? Level { get; set; }
        public int? UserType { get; set; }
    }
}
