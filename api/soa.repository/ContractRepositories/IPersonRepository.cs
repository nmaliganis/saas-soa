using soa.common.infrastructure.Domain;
using soa.common.infrastructure.Domain.Queries;
using soa.model.Persons;

namespace soa.repository.ContractRepositories
{
    public interface IPersonRepository : IRepository<Person, int>
    {
        QueryResult<Person> FindAllPersonsPagedOf(int? pageNum = -1, int? pageSize = -1);
        int FindCountTotals();
        Person FindPersonByNumPlate(string numPlate);
    }
}