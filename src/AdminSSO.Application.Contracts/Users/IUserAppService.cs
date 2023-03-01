using AdminSSO.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace AdminSSO.Users
{
    public interface IUserAppService : IApplicationService, ISingletonDependency
    {
        Task<CustomPagedResultDto<UserDto>> GetList(UserInputSearchDto searchDto);
        Task<UserDto> GetUserById(int Id);
        Task<CreateUserResponseDto> Create(UserInputCreateDto createDto);
        Task<UserDto> Update(UserInputUpdateDto updateDto);
        Task<AutoGenerateInfoUserDto> AutoGenerateInfoUser(string fullName);
        Task<LoginResponse> Login(string userName,string password);
        Task<UserProfileDto> GetUserProfile(string id);

        //Task CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
