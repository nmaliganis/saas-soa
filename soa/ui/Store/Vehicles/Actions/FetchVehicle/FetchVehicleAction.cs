using System;

namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicle
{
  public class FetchVehicleAction
  {
    public Guid VehicleToBeFetchedId { get; private set; }

    public FetchVehicleAction(Guid vehicleToBeFetchedId)
    {
      VehicleToBeFetchedId = vehicleToBeFetchedId;
    }
  }
}