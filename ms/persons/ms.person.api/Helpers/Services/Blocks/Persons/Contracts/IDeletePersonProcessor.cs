using System;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Contracts
{
  public interface IDeletePersonProcessor
  {
    Task<PersonForDeletionUiModel> SoftDeletePersonAsync(Guid accountIdToDeleteThisPerson, int personToBeDeletedId);
    Task<PersonForDeletionUiModel> HardDeletePersonAsync(int personToBeDeletedId);
  }
}