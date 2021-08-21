using System;
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
  public class DeletePersonProcessor : IDeletePersonProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IPersonRepository _personRepository;
    private readonly IAutoMapper _autoMapper;

    public DeletePersonProcessor(IUnitOfWork uOf,
      IPersonRepository personRepository, IAutoMapper autoMapper)
    {
      _uOf = uOf;
      _personRepository = personRepository;
      _autoMapper = autoMapper;
    }

    public Task<PersonForDeletionUiModel> SoftDeletePersonAsync(Guid accountIdToDeleteThisPerson, int personToBeDeletedId)
    {
      var response =
        new PersonForDeletionUiModel()
        {
          Message = "SUCCESS_SOFT_DELETION"
        };

      if (personToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      try
      {
        var personToBeSoftDeleted = _personRepository.FindBy(personToBeDeletedId);

        if (personToBeSoftDeleted == null)
          throw new PersonDoesNotExistException(personToBeDeletedId);

        personToBeSoftDeleted.SoftDeleted();

        Log.Debug(
          $"Update-Delete Person: with Id: {personToBeDeletedId}" +
          "--SoftDeletePerson--  @Ready@ [DeletePersonProcessor]. " +
          "Message: Just Before MakePersonPersistent");

        MakePersonPersistent(personToBeSoftDeleted);

        Log.Debug(
          $"Update-Delete Person: with Id: {personToBeDeletedId}" +
          "--SoftDeletePerson--  @Ready@ [DeletePersonProcessor]. " +
          "Message: Just After MakePersonPersistent");

        response = ThrowExcIfPersonWasNotBeMadePersistent(personToBeSoftDeleted);
        response.Message = "SUCCESS_SOFT_DELETION";
      }
      catch (PersonDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Update-Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeletePerson--  @NotComplete@ [DeletePersonProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (PersonDoesNotExistAfterMadePersistentException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_PERSISTENCE";
        Log.Error(
          $"Update-Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--SoftDeletePerson--  @NotComplete@ [DeletePersonProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Update-Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--SoftDeletePerson--  @fail@ [DeletePersonProcessor]. " +
          $"@innerfault:{exx.Message} and {exx.InnerException}");
      }

      return Task.Run(() => response);
    }

    private PersonForDeletionUiModel ThrowExcIfPersonWasNotBeMadePersistent(Person personToBeSoftDeleted)
    {
      var retrievedPerson =
        _personRepository.FindBy(personToBeSoftDeleted.Id);
      if (retrievedPerson != null)
        return _autoMapper.Map<PersonForDeletionUiModel>(retrievedPerson);
      throw new PersonDoesNotExistAfterMadeTransientException(personToBeSoftDeleted.Id);
    }

    private bool ThrowExcIfPersonWasNotBeMadeTransient(Person personToBeSoftDeleted)
    {
      var retrievedPerson =
        _personRepository.FindBy(personToBeSoftDeleted.Id);
      return retrievedPerson != null
        ? throw new PersonDoesNotExistAfterMadeTransientException(personToBeSoftDeleted.Id)
        : true;
    }

    private void MakePersonPersistent(Person personToBeUpdated)
    {
      _personRepository.Save(personToBeUpdated);
      _uOf.Commit();
    }


    private void MakePersonTransient(Person personToBeSoftDeleted)
    {
      _personRepository.Remove(personToBeSoftDeleted);
      _uOf.Commit();
    }

    public Task<PersonForDeletionUiModel> HardDeletePersonAsync(int personToBeDeletedId)
    {
      var response =
        new PersonForDeletionUiModel()
        {
          Message = "START_HARD_DELETION"
        };

      if (personToBeDeletedId == 0)
      {
        response.Message = "ERROR_INVALID_MEDIA_ITEM_ID";
        return Task.Run(() => response);
      }

      response.Id = personToBeDeletedId;

      try
      {
        var personToBeHardDeleted = _personRepository.FindBy(personToBeDeletedId);

        if (personToBeHardDeleted == null)
          throw new PersonDoesNotExistException(personToBeDeletedId);

        Log.Debug(
          $"Delete Person: with Id: {personToBeDeletedId}" +
          "--HardDeletePersonAsync--  @Ready@ [DeletePersonProcessor]. " +
          "Message: Just Before MakePersonTransient");

        MakePersonTransient(personToBeHardDeleted);

        Log.Debug(
          $"Delete Person: with Id: {personToBeDeletedId}" +
          "--HardDeletePersonAsync--  @Ready@ [DeletePersonProcessor]. " +
          "Message: Just After MakePersonTransient");

        response.DeletionStatus = ThrowExcIfPersonWasNotBeMadeTransient(personToBeHardDeleted);
        response.Message = "SUCCESS_DELETION";
      }
      catch (PersonDoesNotExistException e)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_EXIST";
        Log.Error(
          $"Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeletePerson--  @NotComplete@ [DeletePersonProcessor]. " +
          $"@innerfault:{e?.Message} and {e?.InnerException}");
      }
      catch (PersonDoesNotExistAfterMadeTransientException ex)
      {
        response.Message = "ERROR_MEDIA_ITEM_DOES_NOT_MADE_TRANSIENT";
        Log.Error(
          $"Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          "--HardDeletePerson--  @NotComplete@ [DeletePersonProcessor]. " +
          $"@innerfault:{ex?.Message} and {ex?.InnerException}");
      }
      catch (Exception exxx)
      {
        response.Message = "UNKNOWN_ERROR";
        Log.Error(
          $"Delete Person: Id: {personToBeDeletedId}" +
          $"Error Message:{response.Message}" +
          $"--HardDeletePerson--  @fail@ [DeletePersonProcessor]. " +
          $"@innerfault:{exxx.Message} and {exxx.InnerException}");
      }

      return Task.Run(() => response);
    }
  }
}