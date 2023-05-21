using AdminSSO.RoleMapModuleDtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdminSSO.Authorizations
{
    public class CheckPermissionAttribute : TypeFilterAttribute
    {

        public CheckPermissionAttribute(string permissionName) : base(typeof(CheckPermissionFilter))
        {
            Arguments = new object[] { permissionName };

        }
        private class CheckPermissionFilter : IAsyncActionFilter
        {
            private readonly string _permissionName;
            readonly IRoleMapModuleAppService _roleMapModuleAppService;

            public CheckPermissionFilter(string permissionName, IRoleMapModuleAppService roleMapModuleAppService)
            {
                _permissionName = permissionName;
                _roleMapModuleAppService = roleMapModuleAppService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var user = context.HttpContext.User;

                if (!user.Identity.IsAuthenticated)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var hasPermission = false;

                // Lấy danh sách các policy có trong token

                var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                var policies = await _roleMapModuleAppService.GetRoleByUser(Convert.ToInt32(userId));
                // Kiểm tra policy có tên _permissionName tồn tại trong danh sách hay không
                foreach (var policy in policies)
                {
                    if (policy == _permissionName)
                    {
                        hasPermission = true;
                        break;
                    }
                }

                if (!hasPermission)
                {
                    context.Result = new ForbidResult();
                    return;
                }

                await next();
            }
        }
    }
}
