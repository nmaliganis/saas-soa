using System.Collections.Generic;
using soa.ui.Models.DTOs.Categories;

namespace soa.ui.Store.Categories.Actions.FetchCategories
{
  public class FetchCategoryListSuccessAction
  {
    public List<CategoryDto> CategoryList { get; private set; }

    public FetchCategoryListSuccessAction(List<CategoryDto> categoryList)
    {
      CategoryList  = categoryList;
    }
  }
}