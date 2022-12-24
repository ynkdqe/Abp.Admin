using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdminSSO.Cities
{
    public interface ICityAppService : IApplicationService
    {
        Task<List<CityDto>> GetList();
    }
}
