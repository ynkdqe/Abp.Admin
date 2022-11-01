using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace DuyA.Admin.UserProfiles
{
    public partial class UserProfileDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? Level { get; set; }
        public int? UserType { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifierDate { get; set; }
        public int? LastUpdateBy { get; set; }
        public string Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Gender { get; set; }
        public string CitizenIdentificationNo { get; set; }
        public string IdentityNo { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? WardId { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastChangedPasswordDate { get; set; }
        public int? FailedPasswordAttemptCount { get; set; }
    }
}
