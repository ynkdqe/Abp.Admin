using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AdminSSO.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<List<UserDto>> GetList();
        Task<UserDto> GetUserById(int Id);
        //Task<UserDto> Register(UserInputCreateDto input);

        //Task CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
