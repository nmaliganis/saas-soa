using System;

namespace soa.ui.Store.Categories.Actions.FetchCategory
{
  public class FetchCategoryAction
  {
    public int CategoryToBeFetchedId { get; private set; }

    public FetchCategoryAction(int categoryToBeFetchedId)
    {
      CategoryToBeFetchedId = categoryToBeFetchedId;
    }
  }
}