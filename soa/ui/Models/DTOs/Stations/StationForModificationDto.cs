using System;
using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Stations
{
  public class StationForModificationDto
  {
    public Guid Id { get; set; }
    public string Message { get; set; }
    public string Name { get; set; }
  }
}