namespace smart.charger.webui.Store.Chargers.Actions.DeleteCharger
{
  public class DeleteChargerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public DeleteChargerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}