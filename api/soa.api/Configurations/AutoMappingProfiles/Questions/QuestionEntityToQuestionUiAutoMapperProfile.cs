using AutoMapper;
using soa.common.infrastructure.Vms.Questions;
using soa.model.Questions;

namespace soa.api.Configurations.AutoMappingProfiles.Questions
{
  public class QuestionEntityToQuestionUiAutoMapperProfile : Profile
  {
    public QuestionEntityToQuestionUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Question, QuestionUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}