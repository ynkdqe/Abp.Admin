using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace DuyA.Admin.Wards
{
    public partial class Ward : Entity<int>
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
