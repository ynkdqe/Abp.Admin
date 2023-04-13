using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Roles
{
    public class RoleDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string RoleCode { get; set; }
        public string Description { get; set; }
        public bool? IsActived { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
