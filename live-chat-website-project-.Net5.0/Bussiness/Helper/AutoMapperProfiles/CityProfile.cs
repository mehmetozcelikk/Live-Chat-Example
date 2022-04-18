using AutoMapper;
using Entities.Concrete;
using Entities.ViewModel;

namespace Business.Helper.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>()
                .ForMember(dest => dest.Cities, opt => opt.MapFrom(src => src.CityName))
                .ReverseMap();

            CreateMap<CityDTO, City>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Cities))
                .ReverseMap();
        }
    }
}
