using AutoMapper;
using PlannerAI.Entities.Models;
using Shared.DataTransferObjects;

namespace PlannerAI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDTO>().ForCtorParam("FullAddress", opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

    }
}