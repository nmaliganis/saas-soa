namespace smart.charger.webui.Store.Stations.Actions.FetchVehicle
{
  public class FetchStationFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchStationFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}