namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicles
{
  public class FetchVehicleListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchVehicleListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}