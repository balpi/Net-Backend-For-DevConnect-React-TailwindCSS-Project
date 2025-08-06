
using AutoMapper;

public class BloqMappingProfile : Profile
{
    public BloqMappingProfile()
    {
        CreateMap<Bloq, BloqDto>().ReverseMap();
    }
}