using AdminSSO.Cities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;

namespace AdminSSO.CityControllers
{
    [Area(AdminSSORemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminSSORemoteServiceConsts.RemoteServiceName)]
    [Route("api/city")]
    [Authorize]
    public class CityController : AdminSSOController, ICityAppService
    {
        ICityAppService cityAppService;

        public CityController(ICityAppService cityAppService)
        {
            this.cityAppService = cityAppService;
        }
        [HttpGet]
        public async Task<List<CityDto>> GetList()
        {
            return await this.cityAppService.GetList();
        }
    }
}
