using System;
using System.Threading.Tasks;
using soa.common.infrastructure.PropertyMappings;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Categories;
using soa.contracts.Categories;
using soa.repository.ContractRepositories;

namespace soa.services.Categories
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
