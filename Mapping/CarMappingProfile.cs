using AutoMapper;
using Cars.Entities;
using Cars.Models;

namespace Cars.Mapping;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, CarModel>()
            .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => src.Engine))
            .ForMember(dest => dest.Fabricator, opt => opt.MapFrom(src => src.Manafacturer.Fabricator))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));
            
        CreateMap<EngineModel, EngineModel>() 
            .ForMember(dest => dest.Cars, opt => opt.Ignore()); // Игнорируем список Cars при маппинге
    }
}