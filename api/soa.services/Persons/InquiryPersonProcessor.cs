using System;
using System.Threading.Tasks;
using soa.common.infrastructure.TypeMappings;
using soa.common.infrastructure.Vms.Persons;
using soa.contracts.Persons;
using soa.repository.ContractRepositories;

namespace soa.services.Persons
{
  public class InquiryPersonProcessor : IInquiryPersonProcessor
  {
    private readonly IAutoMapper _autoMapper;
    private readonly IPersonRepository _personRepository;

    public InquiryPersonProcessor(IAutoMapper autoMapper,
      IPersonRepository personRepository)
    {
      _autoMapper = autoMapper;
      _personRepository = personRepository;
    }


    public Task<int> GetPersonCountTotalsAsync()
    {
      return Task.Run(() => _personRepository.FindCountTotals());
    }

    public Task<PersonUiModel> GetPersonByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<PersonUiModel> GetPersonByTitleAsync(string title)
    {
      throw new NotImplementedException();
    }
  }
}
