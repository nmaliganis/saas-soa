using AutoMapper;
using ms.person.api.Helpers.Models;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Configurations.AutoMappingProfiles.Persons
{
  public class PersonEntityToPersonUiAutoMapperProfile : Profile
  {
    public PersonEntityToPersonUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Person, PersonUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Firstname))
        .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
        .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}