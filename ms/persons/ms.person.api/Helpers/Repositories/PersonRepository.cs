using System;
using ms.person.api.Helpers.Models;
using ms.person.api.Helpers.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;
using Serilog;

namespace ms.person.api.Helpers.Repositories
{
  public class PersonRepository : RepositoryBase<Person, int>, IPersonRepository
  {
    public PersonRepository(ISession session)
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
          "--PersonRepository--  @fail@ [PersonRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Person FindPersonByEmail(string email)
    {
      return
        (Person)
        Session.CreateCriteria(typeof(Person))
          .Add(Expression.Eq("Email", email))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
