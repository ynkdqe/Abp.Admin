using AdminSSO.Modules;
using AdminSSO.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Users
{
    public class UserProfileDto : EntityDto<int>
    {
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public string FullName { get; set; }
        public int? LastUpdateBy { get; set; }
        public string Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string CitizenIdentificationNo { get; set; }
        public string IdentityNo { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameAscii { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameAscii { get; set; }
        public int? WardId { get; set; }
        public string WardName { get; set; }
        public string WardNameAscii { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public RoleDto Roles { get; set; }
        public List<ModuleDto> Modules { get; set; }
    }
}
