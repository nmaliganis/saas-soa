namespace smart.charger.webui.Store.Stations.Actions.FetchStation
{
  public class FetchStationListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchStationListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}