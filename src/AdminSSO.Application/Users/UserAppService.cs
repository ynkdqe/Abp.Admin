using AdminSSO.Dtos;
using AdminSSO.Errors;
using AdminSSO.Modules;
using AdminSSO.RoleMapModuleDtos;
using AdminSSO.Roles;
using AdminSSO.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;
using Utility = AdminSSO.Utils.Utility;

namespace AdminSSO.Users
{
    public class UserAppService : AdminSSOAppService, IScopedDependency, IValidationEnabled, IUserAppService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;
        private readonly ILogger<UserAppService> _log;
        private readonly IDistributedCache<object> _cacheUser;
        private readonly IRoleAppService _roleAppService;
        private readonly IRoleMapModuleAppService _roleMapModuleAppService;
        private readonly IModuleAppService _moduleAppService;
        private const string SERVICES_NAME = nameof(UserAppService);
        public UserAppService(IUserRepository userRepository,
            ILogger<UserAppService> log,
            IConfiguration configuration,
            IDistributedCache<object> cacheUser,
            IRoleAppService roleAppService,
            IRoleMapModuleAppService roleMapModuleAppService,
            IModuleAppService moduleAppService
            )
        {
            _userRepository = userRepository;
            _log = log;
            _configuration = configuration;
            _cacheUser = cacheUser;
            _roleAppService = roleAppService;
            _roleMapModuleAppService = roleMapModuleAppService;
            _moduleAppService = moduleAppService;
        }

        //public async Task<List<UserDto>> GetList()
        //{
        //    var result = new CustomPagedResultDto<UserDto>();
        //    var list = await _userRepository.GetListAsync();


        //    return ObjectMapper.Map<List<User>, List<UserDto>>(list);
        //}

        public async Task<UserDto> GetUserById(int Id)
        {
            var key = SERVICES_NAME + "_" + "GetUserById" + "_" + Id.ToString();
            var data = await _cacheUser.GetAsync(key);
            if(data != null)
            {
                return JsonConvert.DeserializeObject<UserDto>(data.ToString());
            }
            
            //return await _cacheUser.GetOrAddAsync(
            //    SERVICES_NAME + "_" + "GetUserById" + "_" + Id.ToString(), //Cache key
            //    async () => 
            //    {
            //        Console.WriteLine("Get data from database");
            //        var user = await _userRepository.GetAsync(c => c.Id == Id);
            //        return ObjectMapper.Map<User, UserDto>(user);
            //    },
            //    () => new DistributedCacheEntryOptions
            //    {
            //        AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
            //    }
            //);
            var user = await _userRepository.GetAsync(c=>c.Id == Id);
            await _cacheUser.SetAsync(key, user);
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<CustomPagedResultDto<UserDto>> GetList(UserInputSearchDto searchDto)
        {
            var result = new CustomPagedResultDto<UserDto>();
            var queryUser = await _userRepository.GetQueryableAsync();
            var listUser = queryUser.WhereIf(!string.IsNullOrEmpty(searchDto.Id), c => c.Id == ConvertUtil.ConvertToInt32(searchDto.Id))
                                    .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword) && searchDto.SearchIn == (int)UserSearchCondition.Name, c => c.FullName.Contains(searchDto.Keyword))
                                    .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword) && searchDto.SearchIn == (int)UserSearchCondition.Phone, c => c.Phone.Contains(searchDto.Keyword))
                                    .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword) && searchDto.SearchIn == (int)UserSearchCondition.Email, c => c.Email.Contains(searchDto.Keyword))
                                    .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword) && searchDto.SearchIn == (int)UserSearchCondition.UserCode, c => c.UserCode.Contains(searchDto.Keyword))
                                    .WhereIf(!string.IsNullOrEmpty(searchDto.Keyword) && searchDto.SearchIn == (int)UserSearchCondition.All,c => 
                                                c.UserCode.Contains(searchDto.Keyword) ||
                                                c.FullName.Contains(searchDto.Keyword) ||
                                                c.Phone.Contains(searchDto.Keyword) ||
                                                c.Email.Contains(searchDto.Keyword) ||
                                                c.UserCode.Contains(searchDto.Keyword));
            
            if (searchDto.Sorting == "desc") listUser = listUser.OrderByDescending(x => x.Id);
            else listUser = listUser.OrderBy(c => c.Id);
            var totalCount = await listUser.CountAsync();
            var list = await listUser.PageBy(((searchDto.PageIndex - 1) * searchDto.PageSize), searchDto.PageSize).ToListAsync();
            var data = new Datas<UserDto>();
            data.Total = totalCount;
            data.CurrentPage = 1;
            data.List = ObjectMapper.Map<List<User>, List<UserDto>>(list);
            result.data = data;
            return result;
        }

        public async Task<CreateUserResponseDto> Create(UserInputCreateDto createDto)
        {
            var result = new CreateUserResponseDto();
            var errors = new ErrorDto();
            try
            {
                var queryUser = await _userRepository.GetQueryableAsync();
                var exitsUser = await queryUser.Where(c => c.UserName == createDto.UserName || c.UserCode == createDto.UserCode || c.Phone == createDto.Phone || c.Email == createDto.Email).FirstOrDefaultAsync();
                if (exitsUser != null)
                {                   
                    errors.code = "User:010001";
                    errors.message = L["User:010002"];
                    result.errors = errors;
                }
                else
                {
                    var input = ObjectMapper.Map<UserInputCreateDto, User>(createDto);
                    //var password = Utility.RandomString(10);
                    var password = "123qwe";
                    AuthenticationShared.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                    input.Password = Convert.ToBase64String(passwordHash);
                    input.PasswordSalt = Convert.ToBase64String(passwordSalt);
                    await _userRepository.InsertAsync(input,true);
                    if (input.Id != 0)
                    {
                        result.Id = input.Id;
                        result.Code = 0;
                        result.Message = L["User:010000"];
                    }
                    else
                    {
                        result.Code = -1;
                        errors.code = "User:010001";
                        errors.message = L["User:010001"];
                        result.errors = errors;
                    }
                }
                
            }
            catch(Exception e)
            {
                throw e;
            }
            return result;
        }

        public Task<UserDto> Update(UserInputUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AutoGenerateInfoUserDto> AutoGenerateInfoUser(string fullName)
        {
            var result = new AutoGenerateInfoUserDto();
            var userName = Utility.GetUserNameByFullName(fullName);
            var listSameUserName = await _userRepository.GetListAsync(c => c.UserName.Contains(userName));
            if(listSameUserName != null && listSameUserName.Any())
            {
                var autoIncrease = 0;
                foreach (var item in listSameUserName)
                {
                    autoIncrease++;
                    var tempUser = userName + autoIncrease.ToString();
                    var exits = listSameUserName.Where(c => c.UserName == tempUser).FirstOrDefault();
                    if (exits == null)
                    {
                        result.UserName = tempUser;
                        break;
                    }                       
                }
            }
            else
            {
                result.UserName = userName;
            }
            var totalRows = await _userRepository.GetCountAsync() + 1;
            result.UserCode = Utility.GetUserCodeByTotalRecords((int)totalRows);
            return result;
        }

        public async Task<LoginResponse> Login(string userName, string password)
        {
            var result = new LoginResponse();
            var queryUser = await _userRepository.GetQueryableAsync();
            var user = await queryUser.Where(c => c.UserName == userName).FirstOrDefaultAsync();
            if(user != null)
            {
                if(AuthenticationShared.VerifyPasswordHash(password, Convert.FromBase64String(user.Password), Convert.FromBase64String(user.PasswordSalt)))
                {
                    var roleBase = 
                    result.Status = 1;
                    result.Message = "Login Success";
                    result.Token = CreateToken(user);
                }
                else
                {
                    result.Status = 10;
                    result.Message = "Password is invalid";
                    result.Token = String.Empty;
                }
            }
            else
            {
                result.Status = 11;
                result.Message = "User not exits";
                result.Token = "";

            }
            return result;
        }

        string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthServer:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                
                claims: claims, 
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public Task<UserProfileDto> GetUserProfile(string id)
        {
            throw new NotImplementedException();
        }
    }
}
