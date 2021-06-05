using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Categories;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Persons;
using soa.repository.ContractRepositories;

namespace soa.services.Persons
{
  public class InquiryAllPersonsProcessor : IInquiryAllPersonsProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IPersonRepository _personRepository;

    public InquiryAllPersonsProcessor(IAutoMapper autoMapper, IPersonRepository personRepository)
    {
      _personRepository = personRepository;
      _autoMapper = autoMapper;
    }

    public Task<List<PersonUiModel>> GetPersonsAsync()
    {
      return Task.Run(() => _personRepository.FindAll().Select(x => _autoMapper.Map<PersonUiModel>(x)).ToList());
    }
  }
}
