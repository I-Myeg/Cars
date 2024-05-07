using AutoMapper;
using Cars.Database.Entities;
using Cars.Domain.Models;

namespace Cars.Domain.Mapping;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, CarModel>()
            .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => src.Engine))
            .ForMember(dest => dest.Fabricator, opt => opt.MapFrom(src => src.Manufacturer.Fabricator))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model));
            
        CreateMap<EngineModel, EngineModel>() 
            .ForMember(dest => dest.Cars, opt => opt.Ignore()); // Игнорируем список Cars при маппинге
    }
}