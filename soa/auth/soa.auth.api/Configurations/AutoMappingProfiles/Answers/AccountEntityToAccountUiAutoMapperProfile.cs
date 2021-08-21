using AutoMapper;
using soa.auth.api.Helpers.Models;
using soa.common.dtos.Vms.Accounts;

namespace soa.auth.api.Configurations.AutoMappingProfiles.Answers
{
  public class AccountEntityToAccountUiAutoMapperProfile : Profile
  {
    public AccountEntityToAccountUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Account, AccountUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}