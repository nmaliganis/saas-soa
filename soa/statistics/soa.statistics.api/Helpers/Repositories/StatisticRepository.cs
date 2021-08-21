using System;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.statistics.api.Helpers.Models;
using soa.statistics.api.Helpers.Repositories.Base;

namespace soa.statistics.api.Helpers.Repositories
{
    public class StatisticRepository : RepositoryBase<Statistic, int>, IStatisticRepository
    {
        public StatisticRepository(ISession session)
            : base(session)
        {
        }

        public int FindCounts()
        {
            int count = 0;
            try
            {
                count = Session
                    .CreateCriteria<NotImplementedException>()
                    .Add(Expression.Eq("IsActive", true))
                    .SetProjection(
                        Projections.Count(Projections.Id())
                    )
                    .UniqueResult<int>();
            }
            catch (Exception e)
            {
                Log.Error(
                    $"FindCountTotals" + $"Error Message:{e.Message}" + 
                    "--StatisticRepository--  @fail@ [StatisticRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
            }

            return count;
        }

        public Statistic FindByBody(string body)
        {
            return
                (Statistic)
                Session.CreateCriteria(typeof(Statistic))
                    .Add(Expression.Eq("NumPlate", body))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }
    }
}