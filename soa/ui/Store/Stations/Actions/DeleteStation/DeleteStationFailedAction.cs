namespace smart.charger.webui.Store.Stations.Actions.DeleteStation
{
  public class DeleteStationFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteStationFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}