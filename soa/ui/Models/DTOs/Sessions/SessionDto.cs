using System;

namespace smart.charger.webui.Models.DTOs.Sessions
{
  public class SessionDto
  {
    public Guid Id { get; set; }
    public DateTime Started { get; set; }
    public  DateTime Ended { get; set; }
    public double Km { get; set; }
    public string Status { get; set; }
    public int StatusIndex { get; set; }
    public double ChargedPercentage { get; set; }
    public double Price { get; set; }
    public double EnergyDelivered { get; set; }
    public string Protocol { get; set; }
    public bool Deleted { get; set; }
    public Guid VehicleId { get; set; }
    public string VehicleComputedInfo { get; set; }
    public string ChargerSerial { get; set; }
    public string VehicleOwnerComputedInfo { get; set; }
    public Guid ChargerId { get; set; }
    public string ChargerComputedInfo { get; set; }
  }
}
