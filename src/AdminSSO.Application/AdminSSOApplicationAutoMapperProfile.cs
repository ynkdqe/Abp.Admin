using AdminSSO.Cities;
using AdminSSO.Districts;
using AdminSSO.UseroOtps;
using AdminSSO.UserOtps;
using AdminSSO.Users;
using AdminSSO.Wards;
using AutoMapper;

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
        CreateMap<UserOtp, UserOtpDto>();
        CreateMap<UserOtpDto, UserOtp>();
        CreateMap<City, CityDto>();
        CreateMap<CityDto, City>();
        CreateMap<District, DistrictDto>();
        CreateMap<DistrictDto, District>();
        CreateMap<Ward, WardDto>();
        CreateMap<WardDto, Ward>();
    }
}
