using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Contracts
{
    public interface IUpdatePersonProcessor
    {
        Task<PersonUiModel> UpdatePersonAsync(int idPersonToBeUpdated, PersonForModificationUiModel updatedPerson);
    }
}
