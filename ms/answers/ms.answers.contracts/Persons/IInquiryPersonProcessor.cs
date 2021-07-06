using System;
using System.Threading.Tasks;
using soa.common.infrastructure.Vms.Persons;

namespace soa.contracts.Persons
{
    public interface IInquiryPersonProcessor
    {
        Task<PersonUiModel> GetPersonByIdAsync(int id);
        Task<PersonUiModel> GetPersonByEmailAsync(string email);
    }
}