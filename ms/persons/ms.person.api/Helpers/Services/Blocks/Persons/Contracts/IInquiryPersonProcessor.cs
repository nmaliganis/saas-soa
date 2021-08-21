using System.Threading.Tasks;
using soa.common.dtos.Vms.Persons;

namespace ms.person.api.Helpers.Services.Blocks.Persons.Contracts
{
    public interface IInquiryPersonProcessor
    {
        Task<PersonUiModel> GetPersonByIdAsync(int id);
        Task<PersonUiModel> GetPersonByEmailAsync(string email);
    }
}