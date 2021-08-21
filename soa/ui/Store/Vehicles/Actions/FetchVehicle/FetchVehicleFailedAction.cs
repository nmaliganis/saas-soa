namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicle
{
  public class FetchVehicleFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchVehicleFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}