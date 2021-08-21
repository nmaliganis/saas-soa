using System;

namespace smart.charger.webui.Store.Vehicles.Actions.DeleteVehicle
{
  public class DeleteVehicleAction
  {
    public Guid VehicleToBeDeletedId { get; private set; }

    public DeleteVehicleAction(Guid vehicleToBeDeletedId)
    {
      VehicleToBeDeletedId = vehicleToBeDeletedId;
    }
  }
}