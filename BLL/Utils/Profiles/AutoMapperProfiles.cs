using AutoMapper;
using BLL.DTOs;
using EntityLayer.Concrete;

namespace BLL.Utils.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GetAllRequest, Person>()
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City)).ReverseMap();
        }
    }
}
