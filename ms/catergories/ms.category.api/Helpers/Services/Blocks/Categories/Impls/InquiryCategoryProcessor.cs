using System;
using System.Threading.Tasks;
using ms.category.api.Helpers.Repositories;
using ms.category.api.Helpers.Services.Blocks.Categories.Contracts;
using soa.common.dtos.Vms.Categories;
using soa.common.infrastructure.TypeMappings;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Impls
{
  public class InquiryCategoryProcessor : IInquiryCategoryProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICategoryRepository _categoryRepository;

    public InquiryCategoryProcessor(IAutoMapper autoMapper,
      ICategoryRepository categoryRepository)
    {
      _autoMapper = autoMapper;
      _categoryRepository = categoryRepository;
    }

    public Task<CategoryUiModel> GetCategoryByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<CategoryUiModel> GetCategoryByNameAsync(string name)
    {
      throw new NotImplementedException();
    }
  }
}
