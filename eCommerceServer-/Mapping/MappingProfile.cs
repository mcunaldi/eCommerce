using AutoMapper;
using eCommerceServer_.Dtos;
using eCommerceServer_.Models;

namespace eCommerceServer_.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, AppUser>();
    }
}
