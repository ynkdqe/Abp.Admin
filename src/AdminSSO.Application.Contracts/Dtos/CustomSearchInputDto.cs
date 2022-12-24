using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Dtos
{
    public class CustomSearchInputDto : PagedAndSortedResultRequestDto
    {
        public string Id { get; set; }
        public string Keyword { get; set; }
    }
}
