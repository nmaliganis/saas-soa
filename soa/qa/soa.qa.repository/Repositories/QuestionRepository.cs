using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using Serilog;
using soa.qa.model.Questions;
using soa.qa.repository.ContractRepositories;
using soa.qa.repository.Repositories.Base;

namespace soa.qa.repository.Repositories
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
          // .CreateCriteria<NotImplementedException>()
          .CreateCriteria<Question>("Q")
          .Add(Expression.Eq("Q.Active", true))
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

    public int FindUnansweredCountTotals()
    {
      int count = 0;
      try
      {
        count = Session
          .CreateCriteria<Question>("Q")
          .CreateCriteria("Q.QuestionAnswers", "QA", JoinType.InnerJoin)
          .Add(Expression.Eq("Q.Active", true))
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

    public IList<Question> FindAllByToday()
    {
      var selection = Session.QueryOver<Question>()
        .Where(t => t.Active)
        .Where(t=>t.CreatedDate < DateTime.Today)
        .List();
      ;

      return selection;
    }
  }
}
