using AutoMapper;
using Cars.Database.Entities;
using Cars.Domain.Models;

namespace Cars.Domain.Mapping;

public class EngineMappingProfile : Profile
{
    public EngineMappingProfile()
    {
        CreateMap<Engine, EngineModel>()
            .ForMember(dest => dest.Cars, opt => opt.Ignore());
    }
}