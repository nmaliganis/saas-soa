using System;
using NHibernate;
using NHibernate.Criterion;
using Serilog;
using soa.qa.model.Categories;
using soa.qa.repository.ContractRepositories;
using soa.qa.repository.Repositories.Base;

namespace soa.qa.repository.Repositories
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
