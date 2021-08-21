using System;

namespace smart.charger.webui.Store.Chargers.Actions.FetchChargers
{
  public class FetchChargerAction
  {
    public Guid ChargerToBeFetchedId { get; private set; }

    public FetchChargerAction(Guid chargerToBeFetchedId)
    {
      ChargerToBeFetchedId = chargerToBeFetchedId;
    }
  }
}