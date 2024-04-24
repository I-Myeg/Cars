using AutoMapper;
using Cars.Entities;
using Cars.Models;

namespace Cars.Mapping;

public class EngineMappingProfile : Profile
{
    public EngineMappingProfile()
    {
        CreateMap<Engine, EngineModel>()
            .ForMember(c => c.Cars, opt => opt.Ignore())
            .PreserveReferences();
    }
}