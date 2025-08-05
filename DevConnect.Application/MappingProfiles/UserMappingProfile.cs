
using AutoMapper;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserCredential, UserLoginResponseDto>();
    }
}