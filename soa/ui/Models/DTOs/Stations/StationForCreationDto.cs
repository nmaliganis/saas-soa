using System;
using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Stations
{
  public class StationForCreationDto
  {
    public string Name { get; set; }
    public Guid ProprietorId { get; set; }
  }
}