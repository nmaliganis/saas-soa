namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicles
{
  public class FetchVehicleListAction
  {
    public string Auth { get; }

    public FetchVehicleListAction(string auth)
    {
      Auth = auth;
    }
  }
}