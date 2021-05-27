using AutoMapper;
using soa.common.infrastructure.Vms.Answers;
using soa.model.Answers;

namespace soa.api.Configurations.AutoMappingProfiles.Answers
{
  public class AnswerEntityToAnswerUiAutoMapperProfile : Profile
  {
    public AnswerEntityToAnswerUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Answer, AnswerUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}