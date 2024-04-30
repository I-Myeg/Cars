using AutoMapper;
using Cars.Entities;
using Cars.Models;

namespace Cars.Mapping;

public class ManafacturerMappingProfile : Profile
{
    public ManafacturerMappingProfile()
    {
        CreateMap<Manafacturer, ManafacturerModel>()
            .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars.Select(car => car.Model)));
    }
    
}