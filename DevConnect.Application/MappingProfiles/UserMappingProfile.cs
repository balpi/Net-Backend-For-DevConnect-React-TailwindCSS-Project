
using AutoMapper;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserCredential, UserLoginResponseDto>()
            .ForPath(d => d.UserName, s => s.MapFrom(op => op.UserProfile.FullName))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
            .ReverseMap();
    }
}