namespace smart.charger.webui.Store.Chargers.Actions.FetchCharger
{
  public class FetchChargerListFailedAction
  {
    public string ErrorMessage { get; private set; }
    public FetchChargerListFailedAction(string errorMessage)
    {
      ErrorMessage = errorMessage;
    }
  }
}