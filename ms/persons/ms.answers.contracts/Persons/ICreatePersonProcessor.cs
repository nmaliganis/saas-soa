using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Persons;

namespace soa.contracts.Persons
{
  public interface ICreatePersonProcessor
  {
    Task<PersonUiModel> CreatePersonAsync(PersonForCreationUiModel newPersonUiModel);
  }
}