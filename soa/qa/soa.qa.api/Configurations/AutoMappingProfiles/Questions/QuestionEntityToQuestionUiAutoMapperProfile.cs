using AutoMapper;
using soa.common.dtos.Vms.Questions;
using soa.qa.model.Questions;

namespace soa.qa.api.Configurations.AutoMappingProfiles.Questions
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
        .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
        .ForMember(dest => dest.Views, opt => opt.MapFrom(src => src.Views))
        .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes))
        .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
        .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
        .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
        .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Person.Id))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}