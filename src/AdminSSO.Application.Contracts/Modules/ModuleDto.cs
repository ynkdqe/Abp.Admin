using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Modules
{
    public class ModuleDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int? AppId { get; set; }
        public string Action { get; set; }
        public int? Level { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public bool? IsActived { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
