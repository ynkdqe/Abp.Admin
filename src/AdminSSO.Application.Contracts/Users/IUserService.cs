using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdminSSO.Users
{
    public interface IUserService : IApplicationService
    {
        Task<List<UserDto>> GetList();
        Task<UserDto> GetUserById(int Id);
    }
}
