using AutoMapper;
using Cars.Entities;
using Cars.Models;

namespace Cars.Mapping;

public class ManafacturerMappingProfile : Profile
{
    public ManafacturerMappingProfile()
    {
        CreateMap<Manafacturer, ManafacturerModel>()
            .ForMember(mm => mm.Cars, opt => opt.MapFrom(p => p.Cars));
    }
    
}