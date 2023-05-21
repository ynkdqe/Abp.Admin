using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.Modules;
using AdminSSO.UseroOtps;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using AutoMapper;
using Volo.Abp.AutoMapper;

namespace AdminSSO;

public class AdminSSOApplicationAutoMapperProfile : Profile
{
    public AdminSSOApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<UserInputCreateDto, User>()
            .Ignore(c=>c.Id)
            .Ignore(c=>c.DateCreated)
            .Ignore(c=>c.ModifierDate)
            .Ignore(c=>c.LastUpdateBy)
            .Ignore(c=>c.Avatar)
            .Ignore(c=>c.Password)
            .Ignore(c=>c.PasswordSalt)
            .Ignore(c=>c.IsDeleted)
            .Ignore(c=>c.LastLockoutDate)
            .Ignore(c=>c.FailedPasswordAttemptCount)
            .Ignore(c=>c.LastLoginDate)
            .Ignore(c=>c.LastChangedPasswordDate)
            ;
        CreateMap<UserOtp, UserOtpDto>();
        CreateMap<UserOtpDto, UserOtp>();
        CreateMap<City, CityDto>();
        CreateMap<CityDto, City>();
        CreateMap<District, DistrictDto>();
        CreateMap<DistrictDto, District>();
        CreateMap<Ward, WardDto>();
        CreateMap<WardDto, Ward>();
        CreateMap<Module, ModuleDto>();
        CreateMap<ModuleDto, Module>();
    }
}
