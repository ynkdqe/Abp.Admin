using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.RoleMapModuleDtos
{
    public class RoleMapModuleDto : EntityDto<int>
    {
        public int? RoleId { get; set; }
        public int? ModuleId { get; set; }
        public string ActionOfRole { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
