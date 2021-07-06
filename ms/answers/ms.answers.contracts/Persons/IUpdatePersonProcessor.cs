using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Persons;

namespace soa.contracts.Persons
{
    public interface IUpdatePersonProcessor
    {
        Task<PersonUiModel> UpdatePersonAsync(int idPersonToBeUpdated, PersonForModificationUiModel updatedPerson);
    }
}
