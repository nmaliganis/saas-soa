using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.common.infrastructure.Domain.Queries;
using soa.common.infrastructure.Paging;
using soa.model.Tags;
using soa.repository.ContractRepositories;
using soa.repository.Repositories.Base;

namespace soa.repository.Repositories
{
  public class TagRepository : RepositoryBase<Tag, int>, ITagRepository
  {
    public TagRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Tag> FindAllTagsPagedOf(int? pageNum, int? pageSize)
    {
      var query = Session.QueryOver<Tag>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Tag>(query?
          .List()
          .AsQueryable());
      }

      return new QueryResult<Tag>(query
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
          "--TagRepository--  @fail@ [TagRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Tag FindTagByNumPlate(string numPlate)
    {
      return
        (Tag)
        Session.CreateCriteria(typeof(Tag))
          .Add(Expression.Eq("NumPlate", numPlate))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
