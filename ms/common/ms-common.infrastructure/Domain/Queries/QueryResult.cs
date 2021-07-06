using System.Collections.Generic;
using System.Linq;
using ms.common.infrastructure.Paging;

namespace ms.common.infrastructure.Domain.Queries
{
  public class QueryResult<T>
  {
    public QueryResult(IQueryable<T> queriedItems, int totalItemCount, int pageSize)
    {
      PageSize = pageSize;
      TotalItemCount = totalItemCount;
      QueriedItems = queriedItems ?? new List<T>().AsQueryable();
    }

    public QueryResult(IQueryable<T> queriedItems)
    {
      QueriedItems = queriedItems ?? new List<T>().AsQueryable();
    }

    public int TotalItemCount { get; }

    public int TotalPageCount => ResultsPagingUtility.CalculatePageCount(TotalItemCount, PageSize);

    public IQueryable<T> QueriedItems { get; set; }

    public int PageSize { get; }
  }
}