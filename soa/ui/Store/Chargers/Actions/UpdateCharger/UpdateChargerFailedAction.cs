namespace smart.charger.webui.Store.Chargers.Actions.UpdateCharger
{
  public class UpdateChargerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public UpdateChargerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}