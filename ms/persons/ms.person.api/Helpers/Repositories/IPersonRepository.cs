using soa.common.infrastructure.Domain;
using soa.qa.model.Persons;

namespace soa.qa.repository.ContractRepositories
{
    public interface IPersonRepository : IRepository<Person, int>
    {
        int FindCountTotals();
        Person FindPersonByEmail(string email);
    }
}