namespace soa.ui.Store.Vehicles.Actions.CreateVehicle
{
  public class CreateVehicleFailedAction
  {
    public string ErrorMessage { get; private set; }
    public string ErrorContent { get; private set; }
    public CreateVehicleFailedAction(string errorMessage, string errorContent)
    {
      ErrorMessage = errorMessage;
      ErrorContent = errorContent;
    }
  }
}