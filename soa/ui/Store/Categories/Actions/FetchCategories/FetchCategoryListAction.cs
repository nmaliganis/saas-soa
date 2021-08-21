namespace soa.ui.Store.Categories.Actions.FetchCategories
{
  public class FetchCategoryListAction
  {
    public string Auth { get; }

    public FetchCategoryListAction(string auth)
    {
      Auth = auth;
    }
  }
}