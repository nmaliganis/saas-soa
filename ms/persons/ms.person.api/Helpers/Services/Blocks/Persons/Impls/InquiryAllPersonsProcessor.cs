using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms.person.api.Helpers.Repositories;
using ms.person.api.Helpers.Services.Blocks.Persons.Contracts;
using soa.common.dtos.Vms.Persons;
using soa.common.infrastructure.TypeMappings;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Impls
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
