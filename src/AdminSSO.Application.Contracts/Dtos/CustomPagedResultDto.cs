using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace AdminSSO.Dtos
{
    public class CustomPagedResultDto<T> 
        //: PagedResultDto<T>
    {
        //public CustomPagedResultDto()
        //{

        //}
        //public CustomPagedResultDto(long totalCount, IReadOnlyList<T> items) : base(totalCount, items)
        //{

        //}
        public int code { get; set; } = 0;
        public Datas<T> data { get; set; }
    }
    public class Datas<T>
    {
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public List<T> List { get; set; }
    }
}
