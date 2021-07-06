using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Persons;

namespace soa.qa.contracts.Persons
{
    public interface IInquiryAllPersonsProcessor
    {
      Task<List<PersonUiModel>> GetPersonsAsync();
    }
}