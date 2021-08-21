using ms.person.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace ms.person.api.Helpers.Repositories
{
    public interface IPersonRepository : IRepository<Person, int>
    {
        int FindCountTotals();
        Person FindPersonByEmail(string email);
    }
}