using ClimFit.Common.DTOs;
using ClimFit.Data.Entities;
using AutoMapper;

namespace ClimFit.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestDepartment, TestDepartmentDto>().ReverseMap();

            CreateMap<TestPerson, TestPersonDto>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name))
                .ForMember(dest => dest.PersonDepartment, opt => opt.MapFrom(src => src.Department))
                .ReverseMap();

            CreateMap<ClothingItem, ClothingItemDto>().ReverseMap();

            CreateMap<OutfitItem, OutfitItemDto>().ReverseMap();
            CreateMap<OutfitSuggestion, OutfitSuggestionDto>().ReverseMap();
            CreateMap<WeatherLog, WeatherLogDto>().ReverseMap();
        }
    }

}
