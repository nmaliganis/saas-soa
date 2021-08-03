using AutoMapper;
using ms.answer.api.Helpers.Models;
using soa.common.dtos.Vms.Answers;

namespace ms.answer.api.Configurations.AutoMappingProfiles.Answers
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
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.Views, opt => opt.MapFrom(src => src.Views))
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .MaxDepth(1)
                .PreserveReferences()
                ;
        }
    }
}