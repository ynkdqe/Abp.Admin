using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace AdminSSO.Users
{
    public class UserService : AdminSSOAppService, ITransientDependency, IValidationEnabled, IUserService
    {
        IUserRepository _userRepository;
        private readonly ILogger<UserService> _log;

        public UserService(IUserRepository userRepository,
            ILogger<UserService> log
            )
        {
            _userRepository = userRepository;
            _log = log;
        }

        public async Task<List<UserDto>> GetList()
        {
            var list = await _userRepository.GetListAsync();
            return ObjectMapper.Map<List<User>, List<UserDto>>(list);
        }

        public async Task<UserDto> GetUserById(int Id)
        {
            var user = await _userRepository.GetAsync(c=>c.Id == Id);
            return ObjectMapper.Map<User, UserDto>(user);
        }
    }
}
