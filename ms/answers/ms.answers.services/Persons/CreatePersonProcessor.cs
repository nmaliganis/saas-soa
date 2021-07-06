using System;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using soa.common.infrastructure.Exceptions.Domain.Persons;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Persons;
using soa.model.Persons;
using soa.repository.ContractRepositories;

namespace soa.services.Persons
{
  public class CreatePersonProcessor : ICreatePersonProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IPersonRepository _personRepository;
    private readonly IAutoMapper _autoMapper;

    public CreatePersonProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IPersonRepository personRepository)
    {
      _uOf = uOf;
      _personRepository = personRepository;
      _autoMapper = autoMapper;
    }
    private void MakePersonPersistent(Person personToBeMadePersistence)
    {
      _personRepository.Save(personToBeMadePersistence);
      _uOf.Commit();
    }
    
    private void ThrowExcIfThisPersonAlreadyExist(Person personToBeCreated)
    {
      var personRetrieved = _personRepository.FindPersonByEmail(personToBeCreated.Email);
      if (personRetrieved != null)
      {
        throw new PersonAlreadyExistsException(personToBeCreated.Email,
          personRetrieved.GetBrokenRulesAsString());
      }
    }

    private PersonUiModel ThrowExcIfPersonWasNotBeMadePersistent(Person personToBeCreated)
    {
      var retrievedPerson = _personRepository.FindPersonByEmail(personToBeCreated.Email);
      if (retrievedPerson != null)
        return _autoMapper.Map<PersonUiModel>(retrievedPerson);
      throw new PersonDoesNotExistAfterMadePersistentException(retrievedPerson.Email);
    }
    
    private void ThrowExcIfPersonCannotBeCreated(Person personToBeCreated)
    {
      bool canBeCreated = !personToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidPersonException(personToBeCreated.GetBrokenRulesAsString());
    }
    
    public Task<PersonUiModel> CreatePersonAsync(PersonForCreationUiModel newPersonUiModel)
    {
      var response =
        new PersonUiModel()
        {
          Message = "START_CREATION"
        };

      if (newPersonUiModel == null)
      {
        response.Message = "ERROR_INVALID_PERSON_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var personToBeCreated = new Person();

        personToBeCreated.InjectWithInitialAttributes(newPersonUiModel);
        
        ThrowExcIfPersonCannotBeCreated(personToBeCreated);
        ThrowExcIfThisPersonAlreadyExist(personToBeCreated);

        Log.Debug(
          $"Create Person: {newPersonUiModel.Email}" +
          "--CreatePerson--  @NotComplete@ [CreatePersonProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakePersonPersistent(personToBeCreated);

        Log.Debug(
          $"Create Person: {newPersonUiModel.Email}" +
          "--CreatePerson--  @NotComplete@ [CreatePersonProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfPersonWasNotBeMadePersistent(personToBeCreated);
        response.Message = "SUCCESS_CREATION";
      }
      catch (InvalidPersonException e)
      {
        response.Message = "ERROR_INVALID_PERSON_MODEL";
        Log.Error(
          $"Create Person: {newPersonUiModel.Email}" +
          $"Error Message:{response.Message}" +
          "--CreatePerson--  @NotComplete@ [CreatePersonProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (PersonAlreadyExistsException ex)
      {
        response.Message = "ERROR_PERSON_ALREADY_EXISTS";
        Log.Error(
          $"Create Person: {newPersonUiModel.Email}" +
          $"Error Message:{response.Message}" +
          "--CreatePerson--  @fail@ [CreatePersonProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (PersonDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_PERSON_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Create Person: {newPersonUiModel.Email}" +
          $"Error Message:{response.Message}" +
          "--CreatePerson--  @fail@ [CreatePersonProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Create Person: {newPersonUiModel.Email}" +
          $"Error Message:{response.Message}" +
          $"--CreatePerson--  @fail@ [CreatePersonProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }
      return Task.Run(() => response);
    }
  }
}
