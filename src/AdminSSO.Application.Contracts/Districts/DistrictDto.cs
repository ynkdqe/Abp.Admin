using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Districts
{
    public class DistrictDto : EntityDto<int>
    {
        public int? CityId { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsShow { get; set; }
        public int? GroupLocation { get; set; }
        public string NameAscii { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
