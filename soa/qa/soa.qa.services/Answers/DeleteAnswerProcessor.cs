using System;
using System.Threading.Tasks;
using Serilog;
using soa.common.dtos.Vms.Answers;
using soa.common.infrastructure.Exceptions.Domain.Answers;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Answers;
using soa.qa.model.Answers;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Answers
{
  public class DeleteAnswerProcessor : IDeleteAnswerProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IAnswerRepository _answerRepository;
    private readonly IAutoMapper _autoMapper;

    public DeleteAnswerProcessor(IUnitOfWork uOf,
      IAnswerRepository answerRepository, IAutoMapper autoMapper)
    {
      _uOf = uOf;
      _answerRepository = answerRepository;
      _autoMapper = autoMapper;
    }

    public Task<AnswerForDeletionUiModel> SoftDeleteAnswerAsync(Guid accountIdToDeleteThisAnswer, int answerToBeDeletedId)
    {
      var response =
        new AnswerForDeletionUiModel()
        {
          Message = "SUCCESS_SOFT_DELETION"
        };

      if (answerToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      try
      {
        var answerToBeSoftDeleted = _answerRepository.FindBy(answerToBeDeletedId);

        if (answerToBeSoftDeleted == null)
          throw new AnswerDoesNotExistException(answerToBeDeletedId);

        answerToBeSoftDeleted.SoftDeleted();

        Log.Debug(
          $"Update-Delete Answer: with Id: {answerToBeDeletedId}" +
          "--SoftDeleteAnswer--  @Ready@ [DeleteAnswerProcessor]. " +
          "Message: Just Before MakeAnswerPersistent");

        MakeAnswerPersistent(answerToBeSoftDeleted);

        Log.Debug(
          $"Update-Delete Answer: with Id: {answerToBeDeletedId}" +
          "--SoftDeleteAnswer--  @Ready@ [DeleteAnswerProcessor]. " +
          "Message: Just After MakeAnswerPersistent");

        response = ThrowExcIfAnswerWasNotBeMadePersistent(answerToBeSoftDeleted);
        response.Message = "SUCCESS_SOFT_DELETION";
      }
      catch (AnswerDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Update-Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteAnswer--  @NotComplete@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (AnswerDoesNotExistAfterMadePersistentException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_PERSISTENCE";
        Log.Error(
          $"Update-Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteAnswer--  @NotComplete@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Update-Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--SoftDeleteAnswer--  @fail@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{exx.Message} and {exx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private AnswerForDeletionUiModel ThrowExcIfAnswerWasNotBeMadePersistent(Answer answerToBeSoftDeleted)
    {
      var retrievedAnswer =
        _answerRepository.FindBy(answerToBeSoftDeleted.Id);
      if (retrievedAnswer != null)
        return _autoMapper.Map<AnswerForDeletionUiModel>(retrievedAnswer);
      throw new AnswerDoesNotExistAfterMadeTransientException(answerToBeSoftDeleted.Id);
    }

    private bool ThrowExcIfAnswerWasNotBeMadeTransient(Answer answerToBeSoftDeleted)
    {
      var retrievedAnswer =
        _answerRepository.FindBy(answerToBeSoftDeleted.Id);
      return retrievedAnswer != null
        ? throw new AnswerDoesNotExistAfterMadeTransientException(answerToBeSoftDeleted.Id)
        : true;
    }

    private void MakeAnswerPersistent(Answer answerToBeUpdated)
    {
      _answerRepository.Save(answerToBeUpdated);
      _uOf.Commit();
    }


    private void MakeAnswerTransient(Answer answerToBeSoftDeleted)
    {
      _answerRepository.Remove(answerToBeSoftDeleted);
      _uOf.Commit();
    }

    public Task<AnswerForDeletionUiModel> HardDeleteAnswerAsync(int answerToBeDeletedId)
    {
      var response =
        new AnswerForDeletionUiModel()
        {
          Message = "START_HARD_DELETION"
        };

      if (answerToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      response.Id = answerToBeDeletedId;

      try
      {
        var answerToBeHardDeleted = _answerRepository.FindBy(answerToBeDeletedId);

        if (answerToBeHardDeleted == null)
          throw new AnswerDoesNotExistException(answerToBeDeletedId);

        Log.Debug(
          $"Delete Answer: with Id: {answerToBeDeletedId}" +
          "--HardDeleteAnswerAsync--  @Ready@ [DeleteAnswerProcessor]. " +
          "Message: Just Before MakeAnswerTransient");

        MakeAnswerTransient(answerToBeHardDeleted);

        Log.Debug(
          $"Delete Answer: with Id: {answerToBeDeletedId}" +
          "--HardDeleteAnswerAsync--  @Ready@ [DeleteAnswerProcessor]. " +
          "Message: Just After MakeAnswerTransient");

        response.DeletionStatus = ThrowExcIfAnswerWasNotBeMadeTransient(answerToBeHardDeleted);
        response.Message = "SUCCESS_DELETION";
      }
      catch (AnswerDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteAnswer--  @NotComplete@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (AnswerDoesNotExistAfterMadeTransientException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_TRANSIENT";
        Log.Error(
          $"Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteAnswer--  @NotComplete@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Delete Answer: Id: {answerToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--HardDeleteAnswer--  @fail@ [DeleteAnswerProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }
  }
}