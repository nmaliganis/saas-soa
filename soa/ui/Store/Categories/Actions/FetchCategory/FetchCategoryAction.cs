using System;

namespace soa.ui.Store.Categories.Actions.FetchCategory
{
  public class FetchCategoryAction
  {
    public Guid CategoryToBeFetchedId { get; private set; }

    public FetchCategoryAction(Guid categoryToBeFetchedId)
    {
      CategoryToBeFetchedId = categoryToBeFetchedId;
    }
  }
}