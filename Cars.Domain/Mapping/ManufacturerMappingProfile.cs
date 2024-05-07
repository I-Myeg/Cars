using AutoMapper;
using Cars.Database.Entities;
using Cars.Domain.Models;

namespace Cars.Domain.Mapping;

public class ManufacturerMappingProfile : Profile
{
    public ManufacturerMappingProfile()
    {
        CreateMap<Manufacturer, ManufacturerModel>()
            .ForMember(dest => dest.Cars, opt => opt.MapFrom(src => src.Cars.Select(car => car.Model)));
    }
    
}