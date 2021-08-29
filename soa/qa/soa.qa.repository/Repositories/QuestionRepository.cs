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
            .Add(Expression.Eq("Q.Active", true))
            .Add(Expression.Eq("Q.Answered", false))
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
      var values =
          Session.CreateCriteria(typeof(Question))
            .Add(Expression.Eq("Active", true))
            .Add(
              Expression.Conjunction()
                .Add(Restrictions.Ge("CreatedDate", DateTime.Today.AddDays(-1)))
                .Add(Restrictions.Lt("CreatedDate", DateTime.Today.AddDays(1)))
            )
            .SetCacheable(true)
            .SetCacheMode(CacheMode.Normal)
            .SetFlushMode(FlushMode.Never)
            .List<Question>()
        ;

      return values;
    }

    public IList<Question> FindAllByUnanswered()
    {
        var selection = Session.QueryOver<Question>()
        .Where(t => t.Active)
        .Where(t => t.Answered == false)
        .List();
      ;

      return selection;
    }
  }
}
