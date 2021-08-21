using AutoMapper;
using ms.category.api.Helpers.Models;
using soa.common.dtos.Vms.Categories;

namespace ms.category.api.Configurations.AutoMappingProfiles.Categories
{
  public class CategoryEntityToCategoryUiAutoMapperProfile : Profile
  {
    public CategoryEntityToCategoryUiAutoMapperProfile()
    {
      ConfigureMapping();
    }

    public void ConfigureMapping()
    {
      CreateMap<Category, CategoryUiModel>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}