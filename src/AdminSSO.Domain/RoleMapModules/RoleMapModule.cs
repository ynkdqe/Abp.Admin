﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace AdminSSO.RoleMapModules
{
    public partial class RoleMapModule : Entity<int>
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