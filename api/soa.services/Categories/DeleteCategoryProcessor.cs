using System;
using System.Threading.Tasks;
using Serilog;
using soa.common.infrastructure.Exceptions.Domain.Categories;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Categories;
using soa.contracts.Categories;
using soa.model.Categories;
using soa.repository.ContractRepositories;

namespace soa.services.Categories
{
  public class DeleteCategoryProcessor : IDeleteCategoryProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public DeleteCategoryProcessor(IUnitOfWork uOf,
      ICategoryRepository categoryRepository, IAutoMapper autoMapper)
    {
      _uOf = uOf;
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    public Task<CategoryForDeletionUiModel> SoftDeleteCategoryAsync(Guid accountIdToDeleteThisCategory, int categoryToBeDeletedId)
    {
      var response =
        new CategoryForDeletionUiModel()
        {
          Message = "SUCCESS_SOFT_DELETION"
        };

      if (categoryToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      try
      {
        var categoryToBeSoftDeleted = _categoryRepository.FindBy(categoryToBeDeletedId);

        if (categoryToBeSoftDeleted == null)
          throw new CategoryDoesNotExistException(categoryToBeDeletedId);

        categoryToBeSoftDeleted.SoftDeleted();

        Log.Debug(
          $"Update-Delete Category: with Id: {categoryToBeDeletedId}" +
          "--SoftDeleteCategory--  @Ready@ [DeleteCategoryProcessor]. " +
          "Message: Just Before MakeCategoryPersistent");

        MakeCategoryPersistent(categoryToBeSoftDeleted);

        Log.Debug(
          $"Update-Delete Category: with Id: {categoryToBeDeletedId}" +
          "--SoftDeleteCategory--  @Ready@ [DeleteCategoryProcessor]. " +
          "Message: Just After MakeCategoryPersistent");

        response = ThrowExcIfCategoryWasNotBeMadePersistent(categoryToBeSoftDeleted);
        response.Message = "SUCCESS_SOFT_DELETION";
      }
      catch (CategoryDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Update-Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteCategory--  @NotComplete@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (CategoryDoesNotExistAfterMadePersistentException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_PERSISTENCE";
        Log.Error(
          $"Update-Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteCategory--  @NotComplete@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Update-Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--SoftDeleteCategory--  @fail@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{exx.Message} and {exx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private CategoryForDeletionUiModel ThrowExcIfCategoryWasNotBeMadePersistent(Category categoryToBeSoftDeleted)
    {
      var retrievedCategory =
        _categoryRepository.FindBy(categoryToBeSoftDeleted.Id);
      if (retrievedCategory != null)
        return _autoMapper.Map<CategoryForDeletionUiModel>(retrievedCategory);
      throw new CategoryDoesNotExistAfterMadeTransientException(categoryToBeSoftDeleted.Id);
    }

    private bool ThrowExcIfCategoryWasNotBeMadeTransient(Category categoryToBeSoftDeleted)
    {
      var retrievedCategory =
        _categoryRepository.FindBy(categoryToBeSoftDeleted.Id);
      return retrievedCategory != null
        ? throw new CategoryDoesNotExistAfterMadeTransientException(categoryToBeSoftDeleted.Id)
        : true;
    }

    private void MakeCategoryPersistent(Category categoryToBeUpdated)
    {
      _categoryRepository.Save(categoryToBeUpdated);
      _uOf.Commit();
    }


    private void MakeCategoryTransient(Category categoryToBeSoftDeleted)
    {
      _categoryRepository.Remove(categoryToBeSoftDeleted);
      _uOf.Commit();
    }

    public Task<CategoryForDeletionUiModel> HardDeleteCategoryAsync(int categoryToBeDeletedId)
    {
      var response =
        new CategoryForDeletionUiModel()
        {
          Message = "START_HARD_DELETION"
        };

      if (categoryToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      response.Id = categoryToBeDeletedId;

      try
      {
        var categoryToBeHardDeleted = _categoryRepository.FindBy(categoryToBeDeletedId);

        if (categoryToBeHardDeleted == null)
          throw new CategoryDoesNotExistException(categoryToBeDeletedId);

        Log.Debug(
          $"Delete Category: with Id: {categoryToBeDeletedId}" +
          "--HardDeleteCategoryAsync--  @Ready@ [DeleteCategoryProcessor]. " +
          "Message: Just Before MakeCategoryTransient");

        MakeCategoryTransient(categoryToBeHardDeleted);

        Log.Debug(
          $"Delete Category: with Id: {categoryToBeDeletedId}" +
          "--HardDeleteCategoryAsync--  @Ready@ [DeleteCategoryProcessor]. " +
          "Message: Just After MakeCategoryTransient");

        response.DeletionStatus = ThrowExcIfCategoryWasNotBeMadeTransient(categoryToBeHardDeleted);
        response.Message = "SUCCESS_DELETION";
      }
      catch (CategoryDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteCategory--  @NotComplete@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (CategoryDoesNotExistAfterMadeTransientException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_TRANSIENT";
        Log.Error(
          $"Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteCategory--  @NotComplete@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Delete Category: Id: {categoryToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--HardDeleteCategory--  @fail@ [DeleteCategoryProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }
  }
}