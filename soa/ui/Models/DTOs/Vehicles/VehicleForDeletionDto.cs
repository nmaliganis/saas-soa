using System;

namespace smart.charger.webui.Models.DTOs.Vehicles
{
  public class VehicleForDeletionDto
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}