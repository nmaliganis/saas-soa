using soa.auth.api.Helpers.Models;
using soa.common.infrastructure.Domain;

namespace soa.auth.api.Helpers.Repositories
{
    public interface IAccountRepository : IRepository<Account, int>
    {
        Account FindByUsername(string username);
    }
}