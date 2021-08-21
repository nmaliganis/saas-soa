namespace smart.charger.webui.Store.Chargers.Actions.FetchCharger
{
  public class FetchChargerListAction
  {
    public string Auth { get; }

    public FetchChargerListAction(string auth)
    {
      Auth = auth;
    }
  }
}