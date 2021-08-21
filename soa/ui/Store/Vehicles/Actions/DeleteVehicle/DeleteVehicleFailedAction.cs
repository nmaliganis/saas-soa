namespace smart.charger.webui.Store.Vehicles.Actions.DeleteVehicle
{
  public class DeleteVehicleFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteVehicleFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}