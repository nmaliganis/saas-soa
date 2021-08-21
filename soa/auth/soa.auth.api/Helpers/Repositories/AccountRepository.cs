using NHibernate;
using NHibernate.Criterion;
using soa.auth.api.Helpers.Models;
using soa.auth.api.Helpers.Repositories.Base;

namespace soa.auth.api.Helpers.Repositories
{
    public class AccountRepository : RepositoryBase<Account, int>, IAccountRepository
    {
        public AccountRepository(ISession session)
            : base(session)
        {
        }
        

        public Account FindByUsername(string username)
        {
            return
                (Account)
                Session.CreateCriteria(typeof(Account))
                    .Add(Expression.Eq("NumPlate", username))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }
    }
}