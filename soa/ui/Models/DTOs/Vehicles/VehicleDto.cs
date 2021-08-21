using System;
using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Vehicles
{
  public class VehicleDto
  {
    public VehicleDto()
    {
      this.Brand = String.Empty;
      this.NumPlate = String.Empty;
      this.ConnectionType = String.Empty;
      this.BatValue = 0;
      this.CurrentKm = 0;
    }
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Brand is required")]
    [MinLength(1, ErrorMessage = "Brand should not be empty")]
    public string Brand { get; set; }
    [Required(ErrorMessage = "Number Plate is required")]
    [MinLength(5, ErrorMessage = "Number Plate should not be empty")]
    public string NumPlate { get; set; }  

    [Required(ErrorMessage = "Connection Type is required")]
    [MinLength(1, ErrorMessage = "Connection type should not be empty")]
    public string ConnectionType { get; set; }
    public double BatValue { get; set; }
    [Required(ErrorMessage = "Current Km are required")]
    public double CurrentKm { get; set; }
    public Guid OwnerId { get; set; }
  }
}
