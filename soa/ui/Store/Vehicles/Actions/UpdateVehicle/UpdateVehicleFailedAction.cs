namespace smart.charger.webui.Store.Vehicles.Actions.UpdateVehicle
{
  public class UpdateVehicleFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateVehicleFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}