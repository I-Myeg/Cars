using AutoMapper;
using Cars.Entities;
using Cars.Models;

namespace Cars.Mapping;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, CarModel>()
            .ForMember(cm => cm.Fabricator, opt => opt.MapFrom(p => p.Manafacturer.Fabricator));
    }
    
}