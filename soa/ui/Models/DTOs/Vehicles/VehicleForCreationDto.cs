using System;

namespace smart.charger.webui.Models.DTOs.Vehicles
{
  public class VehicleForCreationDto
  {
    public string Brand { get; set; }
    public string NumPlate { get; set; }
    public double BatValue { get; set; }
    public double CurrentKm { get; set; }
    public Guid OwnerId { get; set; }
  }
}