using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AdminSSO.Districts
{
    public class District : Entity<int>
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        public string Desciption { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsShow { get; set; }
        public int? GroupLocation { get; set; }
        public string NameAscii { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
