using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace soa.qa.contracts.Persons
{
  public interface ICreatePersonProcessor
  {
    Task<PersonUiModel> CreatePersonAsync(PersonForCreationUiModel newPersonUiModel);
  }
}