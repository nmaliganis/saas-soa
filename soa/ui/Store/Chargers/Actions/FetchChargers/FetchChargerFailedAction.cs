namespace smart.charger.webui.Store.Chargers.Actions.FetchChargers
{
  public class FetchChargerFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchChargerFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}