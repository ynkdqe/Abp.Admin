using AutoMapper;
using DuyA.Admin.UserOtps;
using DuyA.Admin.UserProfiles;

namespace DuyA.Admin;

public class AdminApplicationAutoMapperProfile : Profile
{
    public AdminApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<UserProfile, UserProfileDto>();
        CreateMap<UserProfileDto, UserProfile>();
        CreateMap<UserOtp, UserOtpDto>();
        CreateMap<UserOtpDto, UserOtp>();
    }
}
