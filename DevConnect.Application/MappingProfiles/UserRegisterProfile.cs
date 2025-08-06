
using System.Runtime.InteropServices;
using AutoMapper;

public class UserRegisterProfile : Profile
{
    public UserRegisterProfile()
    {
        CreateMap<UserRegisterDto, UserCredential>()
        .ForPath(d => d.UserProfile.FullName, s => s.MapFrom(x => x.FirstName + " " + x.LastName));
    }
}