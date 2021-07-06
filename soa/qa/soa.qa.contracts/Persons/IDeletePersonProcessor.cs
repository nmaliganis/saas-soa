using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Persons;

namespace soa.qa.contracts.Persons
{
  public interface IDeletePersonProcessor
  {
    Task<PersonForDeletionUiModel> SoftDeletePersonAsync(Guid accountIdToDeleteThisPerson, int personToBeDeletedId);
    Task<PersonForDeletionUiModel> HardDeletePersonAsync(int personToBeDeletedId);
  }
}