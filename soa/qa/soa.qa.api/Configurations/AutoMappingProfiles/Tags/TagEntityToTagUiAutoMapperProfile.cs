using AutoMapper;
using soa.common.dtos.Vms.Tags;
using soa.qa.model.Tags;

namespace soa.qa.api.Configurations.AutoMappingProfiles.Tags
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
        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.TagQuestions.Count))
        .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}