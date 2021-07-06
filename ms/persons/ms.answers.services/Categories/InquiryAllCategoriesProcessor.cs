using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.infrastructure.PropertyMappings;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Categories;
using soa.contracts.Categories;
using soa.repository.ContractRepositories;

namespace soa.services.Categories
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
