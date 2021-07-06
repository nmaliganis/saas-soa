﻿using AutoMapper;
using soa.common.dtos.Vms.Categories;

namespace soa.qa.api.Configurations.AutoMappingProfiles.Category
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
        .MaxDepth(1)
        .PreserveReferences()
        ;
    }
  }
}