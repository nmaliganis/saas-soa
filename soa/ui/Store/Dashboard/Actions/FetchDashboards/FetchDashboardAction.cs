namespace smart.charger.webui.Store.Dashboard.Actions.FetchDashboards
{
  public class FetchDashboardAction
  {
    public string Auth { get; }

    public FetchDashboardAction(string auth)
    {
      Auth = auth;
    }
  }
}