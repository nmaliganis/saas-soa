using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using soa.common.dtos.Vms.Categories;
using soa.common.infrastructure.Exceptions.Domain.Categories;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Categories;
using soa.qa.model.Categories;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Categories
{
  public class UpdateCategoryProcessor : IUpdateCategoryProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdateCategoryProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, ICategoryRepository CategoryRepository)
    {
      _uOf = uOf;
      _categoryRepository = CategoryRepository;
      _autoMapper = autoMapper;
    }
    private void MakeCategoryPersistent(Category categoryToBeMadePersistence)
    {
      _categoryRepository.Save(categoryToBeMadePersistence);
      _uOf.Commit();
    }
    private void ThrowExcIfThisCategoryAlreadyExist(Category categoryToBeCreated)
    {
      var categoryRetrieved = _categoryRepository.FindCategoryByName(categoryToBeCreated.Name);
      if (categoryRetrieved != null)
      {
        throw new CategoryAlreadyExistsException(categoryToBeCreated.Name,
          categoryRetrieved.GetBrokenRulesAsString());
      }
    }

    private CategoryUiModel ThrowExcIfCategoryWasNotBeMadePersistent(Category categoryToBeCreated)
    {
      var retrievedCategory = _categoryRepository.FindCategoryByName(categoryToBeCreated.Name);
      if (retrievedCategory != null)
        return _autoMapper.Map<CategoryUiModel>(retrievedCategory);
      throw new CategoryDoesNotExistAfterMadePersistentException(retrievedCategory.Name);
    }
    
    private void ThrowExcIfCategoryCannotBeModified(Category categoryToBeCreated)
    {
      bool canBeCreated = !categoryToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidCategoryException(categoryToBeCreated.GetBrokenRulesAsString());
    }

    public Task<CategoryUiModel> UpdateCategoryAsync(int idCategoryToBeUpdated, CategoryForModificationUiModel updatedCategory)
    {
      var response =
        new CategoryUiModel()
        {
          Message = "START_CREATION"
        };

      if (updatedCategory == null)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var categoryToBeModified = _categoryRepository.FindBy(idCategoryToBeUpdated);

        categoryToBeModified.InjectWithInitialModifiedAttributes(updatedCategory);
        
        ThrowExcIfCategoryCannotBeModified(categoryToBeModified);
        ThrowExcIfThisCategoryAlreadyExist(categoryToBeModified);

        Log.Debug(
          $"Modify Category: {updatedCategory.Name}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeCategoryPersistent(categoryToBeModified);

        Log.Debug(
          $"Modify Category: {updatedCategory.Name}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfCategoryWasNotBeMadePersistent(categoryToBeModified);
        response.Message = "SUCCESS_MODIFY";
      }
      catch (InvalidCategoryException e)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        Log.Error(
          $"Modify Category: {updatedCategory.Name}" +
          $"Error Message:{response.Message}" +
          "--ModifyCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (CategoryAlreadyExistsException ex)
      {
        response.Message = "ERROR_CATEGORY_ALREADY_EXISTS";
        Log.Error(
          $"Modify Category: {updatedCategory.Name}" +
          $"Error Message:{response.Message}" +
          "--ModifyCategory--  @fail@ [ModifyCategoryProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (CategoryDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_CATEGORY_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Modify Category: {updatedCategory.Name}" +
          $"Error Message:{response.Message}" +
          "--ModifyCategory--  @fail@ [ModifyCategoryProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Modify Category: {updatedCategory.Name}" +
          $"Error Message:{response.Message}" +
          $"--ModifyCategory--  @fail@ [ModifyCategoryProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }
      return Task.Run(() => response);
    }
  }
}
