using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Validation;

namespace AdminSSO.Users
{
    public class UserAppService : AdminSSOAppService, ITransientDependency, IValidationEnabled, IUserAppService
    {
        IUserRepository _userRepository;
        private readonly ILogger<UserAppService> _log;

        public UserAppService(IUserRepository userRepository,
            ILogger<UserAppService> log
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

        //void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using(var hmac = new HMACSHA256())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //public Task<UserDto> Register(UserInputCreateDto input)
        //{
        //    CreatePasswordHash
        //}
    }
}
