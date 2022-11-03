using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Wards
{
    public class WardDto : EntityDto<int>
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public string Description { get; set; }
        public string NameAscii { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
