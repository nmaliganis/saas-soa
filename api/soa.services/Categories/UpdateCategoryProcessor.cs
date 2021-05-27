using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Categories;
using soa.contracts.Categories;
using soa.model.Categories;
using soa.repository.ContractRepositories;

namespace soa.services.Categories
{
  public class UpdateCategoryProcessor : IUpdateCategoryProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdateCategoryProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ICategoryRepository categoryRepository)
    {
      _uOf = uOf;
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }
    private void MakeCategoryPersistent(Category categoryToBeMadePersistence)
    {
      _categoryRepository.Save(categoryToBeMadePersistence);
      _uOf.Commit();
    }

    public Task<CategoryUiModel> UpdateCategoryAsync(int idCategoryToBeUpdated, CategoryForModificationUiModel updatedCategory)
    {
      throw new NotImplementedException();
    }
  }
}
