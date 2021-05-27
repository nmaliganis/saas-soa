using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.common.infrastructure.Domain.Queries;
using soa.common.infrastructure.Paging;
using soa.model.Answers;
using soa.repository.ContractRepositories;
using soa.repository.Repositories.Base;

namespace soa.repository.Repositories
{
  public class AnswerRepository : RepositoryBase<Answer, int>, IAnswerRepository
  {
    public AnswerRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Answer> FindAllAnswersPagedOf(int? pageNum, int? pageSize)
    {
      var query = Session.QueryOver<Answer>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Answer>(query?
          .List()
          .AsQueryable());
      }

      return new QueryResult<Answer>(query
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
