using System;
using System.Threading.Tasks;
using Serilog;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.Exceptions.Domain.Questions;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Questions;
using soa.qa.model.Questions;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Questions
{
  public class DeleteQuestionProcessor : IDeleteQuestionProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IQuestionRepository _questionRepository;
    private readonly IAutoMapper _autoMapper;

    public DeleteQuestionProcessor(IUnitOfWork uOf,
      IQuestionRepository questionRepository, IAutoMapper autoMapper)
    {
      _uOf = uOf;
      _questionRepository = questionRepository;
      _autoMapper = autoMapper;
    }

    public Task<QuestionForDeletionUiModel> SoftDeleteQuestionAsync(Guid accountIdToDeleteThisQuestion, int questionToBeDeletedId)
    {
      var response =
        new QuestionForDeletionUiModel()
        {
          Message = "SUCCESS_SOFT_DELETION"
        };

      if (questionToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      try
      {
        var questionToBeSoftDeleted = _questionRepository.FindBy(questionToBeDeletedId);

        if (questionToBeSoftDeleted == null)
          throw new QuestionDoesNotExistException(questionToBeDeletedId);

        questionToBeSoftDeleted.SoftDeleted();

        Log.Debug(
          $"Update-Delete Question: with Id: {questionToBeDeletedId}" +
          "--SoftDeleteQuestion--  @Ready@ [DeleteQuestionProcessor]. " +
          "Message: Just Before MakeQuestionPersistent");

        MakeQuestionPersistent(questionToBeSoftDeleted);

        Log.Debug(
          $"Update-Delete Question: with Id: {questionToBeDeletedId}" +
          "--SoftDeleteQuestion--  @Ready@ [DeleteQuestionProcessor]. " +
          "Message: Just After MakeQuestionPersistent");

        response = ThrowExcIfQuestionWasNotBeMadePersistent(questionToBeSoftDeleted);
        response.Message = "SUCCESS_SOFT_DELETION";
      }
      catch (QuestionDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Update-Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteQuestion--  @NotComplete@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (QuestionDoesNotExistAfterMadePersistentException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_PERSISTENCE";
        Log.Error(
          $"Update-Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeleteQuestion--  @NotComplete@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Update-Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--SoftDeleteQuestion--  @fail@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{exx.Message} and {exx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private QuestionForDeletionUiModel ThrowExcIfQuestionWasNotBeMadePersistent(Question questionToBeSoftDeleted)
    {
      var retrievedQuestion =
        _questionRepository.FindBy(questionToBeSoftDeleted.Id);
      if (retrievedQuestion != null)
        return _autoMapper.Map<QuestionForDeletionUiModel>(retrievedQuestion);
      throw new QuestionDoesNotExistAfterMadeTransientException(questionToBeSoftDeleted.Id);
    }

    private bool ThrowExcIfQuestionWasNotBeMadeTransient(Question questionToBeSoftDeleted)
    {
      var retrievedQuestion =
        _questionRepository.FindBy(questionToBeSoftDeleted.Id);
      return retrievedQuestion != null
        ? throw new QuestionDoesNotExistAfterMadeTransientException(questionToBeSoftDeleted.Id)
        : true;
    }

    private void MakeQuestionPersistent(Question questionToBeUpdated)
    {
      _questionRepository.Save(questionToBeUpdated);
      _uOf.Commit();
    }


    private void MakeQuestionTransient(Question questionToBeSoftDeleted)
    {
      _questionRepository.Remove(questionToBeSoftDeleted);
      _uOf.Commit();
    }

    public Task<QuestionForDeletionUiModel> HardDeleteQuestionAsync(int questionToBeDeletedId)
    {
      var response =
        new QuestionForDeletionUiModel()
        {
          Message = "START_HARD_DELETION"
        };

      if (questionToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      response.Id = questionToBeDeletedId;

      try
      {
        var questionToBeHardDeleted = _questionRepository.FindBy(questionToBeDeletedId);

        if (questionToBeHardDeleted == null)
          throw new QuestionDoesNotExistException(questionToBeDeletedId);

        Log.Debug(
          $"Delete Question: with Id: {questionToBeDeletedId}" +
          "--HardDeleteQuestionAsync--  @Ready@ [DeleteQuestionProcessor]. " +
          "Message: Just Before MakeQuestionTransient");

        MakeQuestionTransient(questionToBeHardDeleted);

        Log.Debug(
          $"Delete Question: with Id: {questionToBeDeletedId}" +
          "--HardDeleteQuestionAsync--  @Ready@ [DeleteQuestionProcessor]. " +
          "Message: Just After MakeQuestionTransient");

        response.DeletionStatus = ThrowExcIfQuestionWasNotBeMadeTransient(questionToBeHardDeleted);
        response.Message = "SUCCESS_DELETION";
      }
      catch (QuestionDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteQuestion--  @NotComplete@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (QuestionDoesNotExistAfterMadeTransientException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_TRANSIENT";
        Log.Error(
          $"Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeleteQuestion--  @NotComplete@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Delete Question: Id: {questionToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--HardDeleteQuestion--  @fail@ [DeleteQuestionProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }
  }
}