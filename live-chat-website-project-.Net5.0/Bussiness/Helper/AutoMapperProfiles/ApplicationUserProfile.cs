using AutoMapper;
using Entities.Concrete;
using Entities.ViewModel;

namespace Business.Helper.AutoMapperProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            CreateMap<ApplicationUserDTO, ApplicationUser>()
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))

                    .ReverseMap();
        }
    }
}
