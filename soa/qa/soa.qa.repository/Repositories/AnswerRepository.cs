using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
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
          .CreateCriteria<Answer>()
          .Add(Expression.Eq("Active", true))
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

    public IList<Answer> FindAnswersByQuestionId(int questionId)
    {
      return
        Session.CreateCriteria(typeof(Answer))
          .CreateAlias("QuestionAnswer", "qa", JoinType.InnerJoin)
          .CreateAlias("qa.Question", "q", JoinType.InnerJoin)
          .Add(Expression.Eq("q.Id", questionId))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .List<Answer>()
        ;
    }
  }
}
