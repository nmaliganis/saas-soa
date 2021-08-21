using System.Collections.Generic;
using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Contracts
{
    public interface IInquiryAllPersonsProcessor
    {
      Task<List<PersonUiModel>> GetPersonsAsync();
    }
}