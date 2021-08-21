namespace smart.charger.webui.Store.Stations.Actions.FetchStation
{
  public class FetchStationListAction
  {
    public string Auth { get; }

    public FetchStationListAction(string auth)
    {
      Auth = auth;
    }
  }
}