using System;
using ms.tag.api.Helpers.Models;
using ms.tag.api.Helpers.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;
using Serilog;

namespace ms.tag.api.Helpers.Repositories
{
  public class TagRepository : RepositoryBase<Tag, int>, ITagRepository
  {
    public TagRepository(ISession session)
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
          "--TagRepository--  @fail@ [TagRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Tag FindTagByTitle(string title)
    {
      return
        (Tag)
        Session.CreateCriteria(typeof(Tag))
          .Add(Expression.Eq("NumPlate", title))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
