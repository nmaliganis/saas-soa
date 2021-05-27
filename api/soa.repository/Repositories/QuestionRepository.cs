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
    private readonly WKTReader _wkt;

    public QuestionRepository(ISession session)
      : base(session)
    {
      _wkt = new WKTReader();
    }

    public QueryResult<Question> FindAllQuestionsPagedOf(int? pageNum, int? pageSize)
    {
      var query = Session.QueryOver<Question>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Question>(query?
          .List()
          .AsQueryable());
      }

      return new QueryResult<Question>(query
            .Skip(ResultsPagingUtility.CalculateStartIndex((int)pageNum, (int)pageSize))
            .Take((int)pageSize).List().AsQueryable(),
          query.ToRowCountQuery().RowCount(),
          (int)pageSize)
        ;
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

    public Question FindQuestionByNumPlate(string numPlate)
    {
      return
        (Question)
        Session.CreateCriteria(typeof(Question))
          .Add(Expression.Eq("NumPlate", numPlate))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
