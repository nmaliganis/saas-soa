using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms.category.api.Helpers.Repositories;
using ms.category.api.Helpers.Services.Blocks.Categories.Contracts;
using soa.common.dtos.Vms.Categories;
using soa.common.infrastructure.TypeMappings;

namespace ms.category.api.Helpers.Services.Blocks.Categories.Impls
{
  public class InquiryAllCategoriesProcessor : IInquiryAllCategoriesProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly ICategoryRepository _categoryRepository;

    public InquiryAllCategoriesProcessor(IAutoMapper autoMapper, ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    public Task<List<CategoryUiModel>> GetCategoriesAsync()
    {
      return Task.Run(() => _categoryRepository.FindAll().Select(x => _autoMapper.Map<CategoryUiModel>(x)).ToList());
    }
  }
}
