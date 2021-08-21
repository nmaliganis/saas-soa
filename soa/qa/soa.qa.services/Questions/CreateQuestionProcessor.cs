using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using soa.common.dtos.Vms.Questions;
using soa.common.infrastructure.Exceptions.Domain.Categories;
using soa.common.infrastructure.Exceptions.Domain.Persons;
using soa.common.infrastructure.Exceptions.Domain.Questions;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.qa.contracts.Questions;
using soa.qa.model.Questions;
using soa.qa.repository.ContractRepositories;

namespace soa.qa.services.Questions
{
  public class CreateQuestionProcessor : ICreateQuestionProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IQuestionRepository _questionRepository;
    private readonly IPersonRepository _personRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAutoMapper _autoMapper;

    public CreateQuestionProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IQuestionRepository questionRepository, IPersonRepository personRepository, ICategoryRepository categoryRepository)
    {
      _uOf = uOf;
      _questionRepository = questionRepository;
      _personRepository = personRepository;
      _categoryRepository = categoryRepository;
      _autoMapper = autoMapper;
    }

    private void MakeQuestionPersistent(Question questionToBeMadePersistence)
    {
      _questionRepository.Save(questionToBeMadePersistence);
      _uOf.Commit();
    }
    
    private void ThrowExcIfThisQuestionAlreadyExist(Question questionToBeCreated)
    {
      var questionRetrieved = _questionRepository.FindQuestionByTitle(questionToBeCreated.Title);
      if (questionRetrieved != null)
      {
        throw new QuestionAlreadyExistsException(questionToBeCreated.Title,
          questionRetrieved.GetBrokenRulesAsString());
      }
    }

    private QuestionUiModel ThrowExcIfQuestionWasNotBeMadePersistent(Question questionToBeCreated)
    {
      var retrievedQuestion = _questionRepository.FindQuestionByTitle(questionToBeCreated.Title);
      if (retrievedQuestion != null)
        return _autoMapper.Map<QuestionUiModel>(retrievedQuestion);
      throw new QuestionDoesNotExistAfterMadePersistentException(retrievedQuestion.Title);
    }
    
    private void ThrowExcIfQuestionCannotBeCreated(Question questionToBeCreated)
    {
      bool canBeCreated = !questionToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidQuestionException(questionToBeCreated.GetBrokenRulesAsString());
    }
    
    public Task<QuestionUiModel> CreateQuestionAsync(QuestionForCreationUiModel newQuestionUiModel)
    {
      var response =
        new QuestionUiModel()
        {
          Message = "START_CREATION"
        };

      if (newQuestionUiModel == null)
      {
        response.Message = "ERROR_INVALID_QUESTION_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var questionToBeCreated = new Question();

        questionToBeCreated.InjectWithInitialAttributes(newQuestionUiModel);

        var categoryToBeInjected = _categoryRepository.FindBy(newQuestionUiModel.CategoryId);

        if (categoryToBeInjected == null)
          throw new CategoryDoesNotExistException(newQuestionUiModel.CategoryId);

        questionToBeCreated.InjectWithCategory(categoryToBeInjected);
        
        var personToBeInjected = _personRepository.FindBy(newQuestionUiModel.PersonId);

        if (personToBeInjected == null)
          throw new PersonDoesNotExistException(newQuestionUiModel.PersonId);
        
        questionToBeCreated.InjectWithPerson(personToBeInjected);
        
        ThrowExcIfQuestionCannotBeCreated(questionToBeCreated);
        ThrowExcIfThisQuestionAlreadyExist(questionToBeCreated);

        Log.Debug(
          $"Create Question: {newQuestionUiModel.Title}" +
          "--CreateQuestion--  @NotComplete@ [CreateQuestionProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakeQuestionPersistent(questionToBeCreated);

        Log.Debug(
          $"Create Question: {newQuestionUiModel.Title}" +
          "--CreateQuestion--  @NotComplete@ [CreateQuestionProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfQuestionWasNotBeMadePersistent(questionToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (CategoryDoesNotExistException e1)
      {
        response.Message = "ERROR_QUESTION_CATEGORY_NOT_EXISTS";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          "--CreateQuestion--  @fail@ [CreateQuestionProcessor]. " +
          $"@innerfault:{e1?.Message} and {e1?.InnerException}");
      }    
      catch (PersonDoesNotExistException e2)
      {
        response.Message = "ERROR_QUESTION_PERSON_NOT_EXISTS";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          "--CreateQuestion--  @fail@ [CreateQuestionProcessor]. " +
          $"@innerfault:{e2?.Message} and {e2?.InnerException}");
      }  
      catch (InvalidQuestionException e)
      {
        response.Message = "ERROR_INVALID_QUESTION_MODEL";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          "--CreateQuestion--  @NotComplete@ [CreateQuestionProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (QuestionAlreadyExistsException ex)
      {
        response.Message = "ERROR_QUESTION_ALREADY_EXISTS";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          "--CreateQuestion--  @fail@ [CreateQuestionProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (QuestionDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_QUESTION_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          "--CreateQuestion--  @fail@ [CreateQuestionProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Question: {newQuestionUiModel.Title}" +
          $"Error Message:{response.Message}" +
          $"--CreateQuestion--  @fail@ [CreateQuestionProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }
      return Task.Run(() => response);
    }
  }
}
