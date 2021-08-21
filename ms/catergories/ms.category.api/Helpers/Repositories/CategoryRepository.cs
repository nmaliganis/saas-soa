using System;
using ms.category.api.Helpers.Models;
using ms.category.api.Helpers.Repositories.Base;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.qa.model.Categories;

namespace ms.category.api.Helpers.Repositories
{
  public class CategoryRepository : RepositoryBase<Category, int>, ICategoryRepository
  {
    public CategoryRepository(ISession session)
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
          "--CategoryRepository--  @fail@ [CategoryRepository]." + $" @inner-fault:{e?.Message} and {e?.InnerException}");
      }

      return count;
    }

    public Category FindCategoryByName(string name)
    {
      return
        (Category)
        Session.CreateCriteria(typeof(Category))
          .Add(Expression.Eq("Name", name))
          .SetCacheable(true)
          .SetCacheMode(CacheMode.Normal)
          .SetFlushMode(FlushMode.Never)
          .UniqueResult()
        ;
    }
  }
}
