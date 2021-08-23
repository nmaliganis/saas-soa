using AutoMapper;
using soa.common.dtos.Vms.Categories;

namespace soa.qa.api.Configurations.AutoMappingProfiles.Categories
{
  public class CategoryEntityToCategoryUiAutoMapperProfile : Profile
  {
    public CategoryEntityToCategoryUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<qa.model.Categories.Category, CategoryUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Questions.Count))
        .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}