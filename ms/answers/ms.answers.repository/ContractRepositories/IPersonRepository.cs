using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Persons;

namespace soa.repository.ContractRepositories
{
    public interface IPersonRepository : IRepository<Person, int>
    {
        int FindCountTotals();
        Person FindPersonByEmail(string email);
    }
}