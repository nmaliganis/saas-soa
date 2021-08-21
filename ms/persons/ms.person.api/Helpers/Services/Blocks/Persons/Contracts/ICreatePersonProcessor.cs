using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Contracts
{
  public interface ICreatePersonProcessor
  {
    Task<PersonUiModel> CreatePersonAsync(PersonForCreationUiModel newPersonUiModel);
  }
}