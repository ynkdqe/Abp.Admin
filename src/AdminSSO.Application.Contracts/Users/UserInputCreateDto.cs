using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class UserInputCreateDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public int? Level { get; set; }
        public int? UserType { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? IsActive { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        public string CitizenIdentificationNo { get; set; }
        public string IdentityNo { get; set; }
    }
}
