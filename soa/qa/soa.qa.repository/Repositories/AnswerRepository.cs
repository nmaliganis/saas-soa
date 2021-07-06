using System;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.qa.model.Answers;
using soa.qa.repository.ContractRepositories;
using soa.qa.repository.Repositories.Base;

namespace soa.qa.repository.Repositories
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

    public Answer FindAnswerByNumPlate(string numPlate)
    {
      return
        (Answer)
        Session.CreateCriteria(typeof(Answer))
          .Add(Expression.Eq("NumPlate", numPlate))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
