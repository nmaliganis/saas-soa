using System;
using System.Threading.Tasks;
using Serilog;
using soa.common.infrastructure.Exceptions.Domain.Tags;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Tags;
using soa.contracts.Tags;
using soa.model.Tags;
using soa.repository.ContractRepositories;

namespace soa.services.Tags
{
  public class DeleteTagProcessor : IDeleteTagProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly ITagRepository _tagRepository;
    private readonly IAutoMapper _autoMapper;

    public DeleteTagProcessor(IUnitOfWork uOf,
      ITagRepository tagRepository, IAutoMapper autoMapper)
    {
      _uOf = uOf;
      _tagRepository = tagRepository;
      _autoMapper = autoMapper;
    }

    public Task<TagForDeletionUiModel> SoftDeleteTagAsync(Guid accountIdToDeleteThisTag, int tagToBeDeletedId)
    {
      var response =
        new TagForDeletionUiModel()
        {
          Message = "SUCCESS_SOFT_DELETION"
        };

      if (tagToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      try
      {
        var tagToBeSoftDeleted = _tagRepository.FindBy(tagToBeDeletedId);

        if (tagToBeSoftDeleted == null)
          throw new TagDoesNotExistException(tagToBeDeletedId);

        tagToBeSoftDeleted.SoftDeleted();

        Log.Debug(
          $"Update-Delete Tag: with Id: {tagToBeDeletedId}" +
          "--SoftDeleteTag--  @Ready@ [DeleteTagProcessor]. " +
          "Message: Just Before MakeTagPersistent");

        MakeTagPersistent(tagToBeSoftDeleted);

        Log.Debug(
          $"Update-Delete Tag: with Id: {tagToBeDeletedId}" +
          "--SoftDeleteTag--  @Ready@ [DeleteTagProcessor]. " +
          "Message: Just After MakeTagPersistent");

        response = ThrowExcIfTagWasNotBeMadePersistent(tagToBeSoftDeleted);
        response.Message = "SUCCESS_SOFT_DELETION";
      }
      catch (TagDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Update-Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteTag--  @NotComplete@ [DeleteTagProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (TagDoesNotExistAfterMadePersistentException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_PERSISTENCE";
        Log.Error(
          $"Update-Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteTag--  @NotComplete@ [DeleteTagProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Update-Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--SoftDeleteTag--  @fail@ [DeleteTagProcessor]. " +
          $"@innerfault:{exx.Message} and {exx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private TagForDeletionUiModel ThrowExcIfTagWasNotBeMadePersistent(Tag tagToBeSoftDeleted)
    {
      var retrievedTag =
        _tagRepository.FindBy(tagToBeSoftDeleted.Id);
      if (retrievedTag != null)
        return _autoMapper.Map<TagForDeletionUiModel>(retrievedTag);
      throw new TagDoesNotExistAfterMadeTransientException(tagToBeSoftDeleted.Id);
    }

    private bool ThrowExcIfTagWasNotBeMadeTransient(Tag tagToBeSoftDeleted)
    {
      var retrievedTag =
        _tagRepository.FindBy(tagToBeSoftDeleted.Id);
      return retrievedTag != null
        ? throw new TagDoesNotExistAfterMadeTransientException(tagToBeSoftDeleted.Id)
        : true;
    }

    private void MakeTagPersistent(Tag tagToBeUpdated)
    {
      _tagRepository.Save(tagToBeUpdated);
      _uOf.Commit();
    }


    private void MakeTagTransient(Tag tagToBeSoftDeleted)
    {
      _tagRepository.Remove(tagToBeSoftDeleted);
      _uOf.Commit();
    }

    public Task<TagForDeletionUiModel> HardDeleteTagAsync(int tagToBeDeletedId)
    {
      var response =
        new TagForDeletionUiModel()
        {
          Message = "START_HARD_DELETION"
        };

      if (tagToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      response.Id = tagToBeDeletedId;

      try
      {
        var tagToBeHardDeleted = _tagRepository.FindBy(tagToBeDeletedId);

        if (tagToBeHardDeleted == null)
          throw new TagDoesNotExistException(tagToBeDeletedId);

        Log.Debug(
          $"Delete Tag: with Id: {tagToBeDeletedId}" +
          "--HardDeleteTagAsync--  @Ready@ [DeleteTagProcessor]. " +
          "Message: Just Before MakeTagTransient");

        MakeTagTransient(tagToBeHardDeleted);

        Log.Debug(
          $"Delete Tag: with Id: {tagToBeDeletedId}" +
          "--HardDeleteTagAsync--  @Ready@ [DeleteTagProcessor]. " +
          "Message: Just After MakeTagTransient");

        response.DeletionStatus = ThrowExcIfTagWasNotBeMadeTransient(tagToBeHardDeleted);
        response.Message = "SUCCESS_DELETION";
      }
      catch (TagDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteTag--  @NotComplete@ [DeleteTagProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (TagDoesNotExistAfterMadeTransientException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_TRANSIENT";
        Log.Error(
          $"Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteTag--  @NotComplete@ [DeleteTagProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Delete Tag: Id: {tagToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--HardDeleteTag--  @fail@ [DeleteTagProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }
  }
}