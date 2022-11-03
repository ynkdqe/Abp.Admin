using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Cities
{
    public class CityDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsShow { get; set; }
        public int? DisplayOrder { get; set; }
        public string GroupLocation { get; set; }
        public string NameAscii { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
