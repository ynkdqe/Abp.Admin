using AdminSSO.Dtos;
using AdminSSO.Errors;
using AdminSSO.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;
using Utility = AdminSSO.Utils.Utility;

namespace AdminSSO.Users
{
    public class UserAppService : AdminSSOAppService, ITransientDependency, IValidationEnabled, IUserAppService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;
        private readonly ILogger<UserAppService> _log;

        public UserAppService(IUserRepository userRepository,
            ILogger<UserAppService> log,
            IConfiguration configuration
            )
        {
            _userRepository = userRepository;
            _log = log;
            _configuration = configuration;

        }

        //public async Task<List<UserDto>> GetList()
        //{
        //    var result = new CustomPagedResultDto<UserDto>();
        //    var list = await _userRepository.GetListAsync();


        //    return ObjectMapper.Map<List<User>, List<UserDto>>(list);
        //}

        public async Task<UserDto> GetUserById(int Id)
        {
            var user = await _userRepository.GetAsync(c=>c.Id == Id);
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
                    var password = Utility.RandomString(10);
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
            result.UserName = Utility.GetUserNameByFullName(fullName);
            var totalRows = await _userRepository.GetCountAsync();
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
                if(AuthenticationShared.VerifyPasswordHash(password, Encoding.ASCII.GetBytes(user.Password), Encoding.ASCII.GetBytes(user.PasswordSalt)))
                {
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
        //async Task<JwtAuththenticationResponse> Authenticate(string userName,string password)
        //{
        //    // validating username and password
        //    var user = await _userRepository.GetAsync(c=>c.UserName == userName && c.Password == password);
        //    if(user != null)
        //    {
        //        var tokenExpiry = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
        //        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        //        var tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
        //        var securityTokenDescription = new SecurityTokenDescriptor
        //        {
        //            Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
        //            {
        //                new Claim("username", userName),
        //                new Claim(ClaimTypes.PrimaryGroupSid, user.UserCode),

        //            }),
        //            Expires = tokenExpiry,
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescription);
        //        var token = jwtSecurityTokenHandler.WriteToken(securityToken);
        //        return new JwtAuththenticationResponse
        //        {
        //            token = token,
        //            user_name = userName,
        //            expires_in = (int)tokenExpiry.Subtract(DateTime.Now).TotalSeconds
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public LoginResponse Login(string userName, string password)
        //{
        //    var auth = Authenticate(userName, password);
        //    return OkObjectResult(auth);
        //}

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
