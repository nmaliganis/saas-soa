using System;
using System.Collections.Generic;
using Fluxor;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories
{
  public class CategoryFeature : Feature<CategoryState>
  {
    public override string GetName() => "Category";

    protected override CategoryState GetInitialState() => new CategoryState(
      new List<CategoryDto>(), 
      "",
      true,
      new CategoryDto(), 
      new CategoryForCreationDto(), 
      new CategoryForModificationDto(), 
      0
    );
  }
}