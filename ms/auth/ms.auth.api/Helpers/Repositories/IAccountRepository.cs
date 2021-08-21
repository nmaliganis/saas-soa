using ms.auth.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace ms.auth.api.Helpers.Repositories
{
    public interface IAccountRepository : IRepository<Account, int>
    {
        Account FindByUsername(string username);
    }
}