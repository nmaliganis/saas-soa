namespace smart.charger.webui.Store.Stations.Actions.UpdatesStation
{
  public class UpdateStationFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateStationFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}