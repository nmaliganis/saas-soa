using System;
using System.Linq;
using System.Threading.Tasks;
using ms.person.api.Helpers.Models;
using ms.person.api.Helpers.Repositories;
using ms.person.api.Helpers.Services.Blocks.Persons.Contracts;
using Serilog;
using soa.common.dtos.Vms.Persons;
using soa.common.infrastructure.Exceptions.Domain.Persons;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Impls
{
  public class UpdatePersonProcessor : IUpdatePersonProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IPersonRepository _personRepository;
    private readonly IAutoMapper _autoMapper;

    public UpdatePersonProcessor(IUnitOfWork uOf, IAutoMapper autoMapper, IPersonRepository personRepository)
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
    
    private void ThrowExcIfPersonCannotBeModified(Person personToBeCreated)
    {
      bool canBeCreated = !personToBeCreated.GetBrokenRules().Any();
      if (!canBeCreated)
        throw new InvalidPersonException(personToBeCreated.GetBrokenRulesAsString());
    }

    public Task<PersonUiModel> UpdatePersonAsync(int idPersonToBeUpdated, PersonForModificationUiModel updatedPerson)
    {
      var response =
        new PersonUiModel()
        {
          Message = "START_CREATION"
        };

      if (updatedPerson == null)
      {
        response.Message = "ERROR_INVALID_PERSON_MODEL";
        return Task.Run(() => response);
      }

      try
      {
        var personToBeModified = _personRepository.FindPersonByEmail(updatedPerson.Email);

        personToBeModified.InjectWithInitialModifiedAttributes(updatedPerson);
        
        ThrowExcIfPersonCannotBeModified(personToBeModified);
        ThrowExcIfThisPersonAlreadyExist(personToBeModified);

        Log.Debug(
          $"Modify Person: {updatedPerson.Email}" +
          "--CreatePerson--  @NotComplete@ [CreatePersonProcessor]. " +
          "Message: Just Before MakeItPersistence");

        MakePersonPersistent(personToBeModified);

        Log.Debug(
          $"Modify Person: {updatedPerson.Email}" +
          "--CreatePerson--  @NotComplete@ [CreatePersonProcessor]. " +
          "Message: Just After MakeItPersistence");
        response = ThrowExcIfPersonWasNotBeMadePersistent(personToBeModified);
        response.Message = "SUCCESS_MODIFY";
      }
      catch (InvalidPersonException e)
      {
        response.Message = "ERROR_INVALID_PERSON_MODEL";
        Log.Error(
          $"Modify Person: {updatedPerson.Email}" +
          $"Error Message:{response.Message}" +
          "--ModifyPerson--  @NotComplete@ [CreatePersonProcessor]. " +
          $"Broken rules: {e.BrokenRules}");
      }
      catch (PersonAlreadyExistsException ex)
      {
        response.Message = "ERROR_PERSON_ALREADY_EXISTS";
        Log.Error(
          $"Modify Person: {updatedPerson.Email}" +
          $"Error Message:{response.Message}" +
          "--ModifyPerson--  @fail@ [ModifyPersonProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (PersonDoesNotExistAfterMadePersistentException exx)
      {
        response.Message = "ERROR_PERSON_NOT_MADE_PERSISTENT";
        Log.Error(
          $"Modify Person: {updatedPerson.Email}" +
          $"Error Message:{response.Message}" +
          "--ModifyPerson--  @fail@ [ModifyPersonProcessor]." +
          $" @innerfault:{exx?.Message} and {exx?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Modify Person: {updatedPerson.Email}" +
          $"Error Message:{response.Message}" +
          $"--ModifyPerson--  @fail@ [ModifyPersonProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }
      return Task.Run(() => response);
    }
  }
}
