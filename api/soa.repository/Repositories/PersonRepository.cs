using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.common.infrastructure.Domain.Queries;
using soa.common.infrastructure.Paging;
using soa.model.Persons;
using soa.repository.ContractRepositories;
using soa.repository.Repositories.Base;

namespace soa.repository.Repositories
{
  public class PersonRepository : RepositoryBase<Person, int>, IPersonRepository
  {
    public PersonRepository(ISession session)
      : base(session)
    {
    }

    public QueryResult<Person> FindAllPersonsPagedOf(int? pageNum, int? pageSize)
    {
      var query = Session.QueryOver<Person>();

      if (pageNum == -1 & pageSize == -1)
      {
        return new QueryResult<Person>(query?
          .List()
          .AsQueryable());
      }

      return new QueryResult<Person>(query
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
          "--PersonRepository--  @fail@ [PersonRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Person FindPersonByNumPlate(string numPlate)
    {
      return
        (Person)
        Session.CreateCriteria(typeof(Person))
          .Add(Expression.Eq("NumPlate", numPlate))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
