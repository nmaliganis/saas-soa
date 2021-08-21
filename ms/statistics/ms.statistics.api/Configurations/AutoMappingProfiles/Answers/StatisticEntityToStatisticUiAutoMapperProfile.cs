using AutoMapper;
using soa.common.dtos.Vms.Statistics;
using soa.statistics.api.Helpers.Models;

namespace soa.statistics.api.Configurations.AutoMappingProfiles.Answers
{
  public class StatisticEntityToStatisticUiAutoMapperProfile : Profile
  {
    public StatisticEntityToStatisticUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Statistic, StatisticUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}