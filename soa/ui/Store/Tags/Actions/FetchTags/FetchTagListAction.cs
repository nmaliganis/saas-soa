namespace soa.ui.Store.Tags.Actions.FetchTags
{
  public class FetchTagListAction
  {
    public string Auth { get; }

    public FetchTagListAction(string auth)
    {
      Auth = auth;
    }
  }
}