using AdminSSO.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminSSO.Users
{
    public class UserInputSearchDto : CustomSearchInputDto
    {
        public int? SearchIn { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
}
