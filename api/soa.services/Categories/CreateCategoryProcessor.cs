using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Categories;
using soa.contracts.Categories;
using soa.repository.ContractRepositories;

namespace soa.services.Categories
{
  public class CreateCategoryProcessor : ICreateCategoryProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateCategoryProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      ICategoryRepository categoryRepository)
    {
      _uOf = uOf;
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    public Task<CategoryUiModel> CreateCategoryAsync(CategoryForCreationUiModel newCategoryUiModel)
    {
      return null;
    }
  }
}
