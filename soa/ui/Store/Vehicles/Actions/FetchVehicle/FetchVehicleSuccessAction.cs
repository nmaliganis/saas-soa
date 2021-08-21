using smart.charger.webui.Models.DTOs.Vehicles;

namespace smart.charger.webui.Store.Vehicles.Actions.FetchVehicle
{
  public class FetchVehicleSuccessAction
  {
    public VehicleDto VehicleToHaveBeenFetched { get; private set; }

    public FetchVehicleSuccessAction(VehicleDto vehicleToHaveBeenFetched)
    {
      VehicleToHaveBeenFetched  = vehicleToHaveBeenFetched;
    }
  }
}