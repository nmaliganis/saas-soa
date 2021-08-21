using System;
using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Stations
{
  public class StationForDeletionDto
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}