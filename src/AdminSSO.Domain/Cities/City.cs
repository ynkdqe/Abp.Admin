using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AdminSSO.Cities
{
    public class City : Entity<int>
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
