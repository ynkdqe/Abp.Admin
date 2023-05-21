using AdminSSO.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace AdminSSO.ModuleControllers
{
    [Area(AdminSSORemoteServiceConsts.ModuleName)]
    [RemoteService(Name = AdminSSORemoteServiceConsts.RemoteServiceName)]
    [Route("api/module")]
    public class ModuleController : AdminSSOController
    {
        IModuleAppService _moduleAppService;
        public ModuleController(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }
        [HttpGet]
        [Route("get-by-user")]
        public async Task<IActionResult> GetModuleByUserAsync()
        {
            var module = await _moduleAppService.GetModuleByUserAsync();
            return Ok(module);

            
        }
    }
}
