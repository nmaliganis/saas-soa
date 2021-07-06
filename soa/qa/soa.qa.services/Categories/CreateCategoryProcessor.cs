using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using soa.common.infrastructure.Exceptions.Domain.Categories;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Categories;
using soa.qa.contracts.Categories;
using soa.qa.model.Categories;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Categories
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

    private void MakeCategoryPersistent(Category CategoryToBeMadePersistence)
    {
      _categoryRepository.Save(CategoryToBeMadePersistence);
      _uOf.Commit();
    }
    
    private void ThrowExcIfThisCategoryAlreadyExist(Category CategoryToBeCreated)
    {
      var categoryRetrieved = _categoryRepository.FindCategoryByName(CategoryToBeCreated.Name);
      if (categoryRetrieved != null)
      {
        throw new CategoryAlreadyExistsException(CategoryToBeCreated.Name,
          categoryRetrieved.GetBrokenRulesAsString());
      }
    }

    private CategoryUiModel ThrowExcIfCategoryWasNotBeMadePersistent(Category CategoryToBeCreated)
    {
      var retrievedCategory = _categoryRepository.FindCategoryByName(CategoryToBeCreated.Name);
      if (retrievedCategory != null)
        return _autoMapper.Map<CategoryUiModel>(retrievedCategory);
      throw new CategoryDoesNotExistAfterMadePersistentException(retrievedCategory.Name);
    }
    
    private void ThrowExcIfCategoryCannotBeCreated(Category CategoryToBeCreated)
    {
      bool canBeCreated = !CategoryToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidCategoryException(CategoryToBeCreated.GetBrokenRulesAsString());
    }
    
    public Task<CategoryUiModel> CreateCategoryAsync(CategoryForCreationUiModel newCategoryUiModel)
    {
      var response =
        new CategoryUiModel()
        {
          Message = "START_CREATION"
        };

      if (newCategoryUiModel == null)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var categoryToBeCreated = new Category();

        categoryToBeCreated.InjectWithInitialAttributes(newCategoryUiModel);
        
        ThrowExcIfCategoryCannotBeCreated(categoryToBeCreated);
        ThrowExcIfThisCategoryAlreadyExist(categoryToBeCreated);

        Log.Debug(
          $"Create Category: {newCategoryUiModel.Name}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeCategoryPersistent(categoryToBeCreated);

        Log.Debug(
          $"Create Category: {newCategoryUiModel.Name}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfCategoryWasNotBeMadePersistent(categoryToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (InvalidCategoryException e)
      {
        response.Message = "ERROR_INVALID_CATEGORY_MODEL";
        Log.Error(
          $"Create Category: {newCategoryUiModel.Name}" +
          $"Error Message:{response.Message}" +
          "--CreateCategory--  @NotComplete@ [CreateCategoryProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (CategoryAlreadyExistsException ex)
      {
        response.Message = "ERROR_CATEGORY_ALREADY_EXISTS";
        Log.Error(
          $"Create Category: {newCategoryUiModel.Name}" +
          $"Error Message:{response.Message}" +
          "--CreateCategory--  @fail@ [CreateCategoryProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (CategoryDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_CATEGORY_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Category: {newCategoryUiModel.Name}" +
          $"Error Message:{response.Message}" +
          "--CreateCategory--  @fail@ [CreateCategoryProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Category: {newCategoryUiModel.Name}" +
          $"Error Message:{response.Message}" +
          $"--CreateCategory--  @fail@ [CreateCategoryProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }
      return Task.Run(() => response);
    }
  }
}
