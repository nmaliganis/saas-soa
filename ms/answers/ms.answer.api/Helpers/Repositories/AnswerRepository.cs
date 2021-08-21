using System;
using ms.answer.api.Helpers.Models;
using ms.answer.api.Helpers.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;
using Serilog;

namespace ms.answer.api.Helpers.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer, int>, IAnswerRepository
    {
        public AnswerRepository(ISession session)
            : base(session)
        {
        }

        public int FindCountTotals()
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
                    "--AnswerRepository--  @fail@ [AnswerRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
            }

            return count;
        }

        public Answer FindAnswerByTitle(string title)
        {
            return
                (Answer)
                Session.CreateCriteria(typeof(Answer))
                    .Add(Expression.Eq("NumPlate", title))
                    .SetCacheable(true)
                    .SetCacheMode(CacheMode.Normal)
                    .SetFlushMode(FlushMode.Never)
                    .UniqueResult()
                ;
        }
    }
}