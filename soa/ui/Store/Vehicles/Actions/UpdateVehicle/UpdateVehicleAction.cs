using System;

namespace smart.charger.webui.Store.Vehicles.Actions.UpdateVehicle
{
  public class UpdateVehicleAction
  {
    public Guid VehicleToBeUpdateId { get; private set; }

    public UpdateVehicleAction(Guid vehicleToBeUpdateId)
    {
      VehicleToBeUpdateId = vehicleToBeUpdateId;
    }
  }
}