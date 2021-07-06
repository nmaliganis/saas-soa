using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace soa.qa.contracts.Persons
{
    public interface IUpdatePersonProcessor
    {
        Task<PersonUiModel> UpdatePersonAsync(int idPersonToBeUpdated, PersonForModificationUiModel updatedPerson);
    }
}
