using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.UnitOfWorks;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Persons;
using soa.repository.ContractRepositories;

namespace soa.services.Persons
{
  public class CreatePersonProcessor : ICreatePersonProcessor
  {
    private readonly IUnitOfWork _uOf;
    private readonly IPersonRepository _personRepository;
    private readonly IAutoMapper _autoMapper;

    public CreatePersonProcessor(IUnitOfWork uOf, IAutoMapper autoMapper,
      IPersonRepository personRepository)
    {
      _uOf = uOf;
      _personRepository = personRepository;
      _autoMapper = autoMapper;
    }

    public Task<PersonUiModel> CreatePersonAsync(PersonForCreationUiModel newPersonUiModel)
    {
      return null;
    }
  }
}
