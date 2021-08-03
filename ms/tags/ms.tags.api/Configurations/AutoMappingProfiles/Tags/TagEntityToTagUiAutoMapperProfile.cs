using AutoMapper;
using ms.tag.api.Helpers.Models;
using soa.common.dtos.Vms.Tags;

namespace ms.tag.api.Configurations.AutoMappingProfiles.Tags
{
  public class TagEntityToTagUiAutoMapperProfile : Profile
  {
    public TagEntityToTagUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Tag, TagUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}