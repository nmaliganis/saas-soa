using smart.charger.webui.Models.DTOs.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Actions.CreateVehicle
{
  public class CreateVehicleAction
  {
    public CreateVehicleAction(VehicleForCreationDto vehicleToBeCreatedPayload)
    {
      VehicleToBeCreatedPayload = vehicleToBeCreatedPayload;
    }

    public VehicleForCreationDto VehicleToBeCreatedPayload { get; private set; }
  }
}