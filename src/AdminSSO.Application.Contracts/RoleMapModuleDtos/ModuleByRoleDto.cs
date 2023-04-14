using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.RoleMapModuleDtos
{
    public class ModuleByRoleDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleModule { get; set; }
        
        public string RoleCode { get; set; }
    }
}
