using System;
using System.Linq;
using NetTopologySuite.IO;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.common.infrastructure.Domain.Queries;
using soa.common.infrastructure.Paging;
using soa.model.Questions;
using soa.repository.ContractRepositories;
using soa.repository.Repositories.Base;

namespace soa.repository.Repositories
{
  public class QuestionRepository : RepositoryBase<Question, int>, IQuestionRepository
  {
    public QuestionRepository(ISession session)
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
          "--QuestionRepository--  @fail@ [QuestionRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Question FindQuestionByTitle(string title)
    {
      return
        (Question)
        Session.CreateCriteria(typeof(Question))
          .Add(Expression.Eq("Title", title))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
