using System;
using System.ComponentModel.DataAnnotations;

namespace smart.charger.webui.Models.DTOs.Stations
{
  public class StationDto
  {
    public Guid Id { get; set; }
    public string Message { get; set; }

    public string Name { get; set; }

    public double Rating { get; set; }

    public double Latitude { get; set; }

    public double Longitude  { get; set; }
  }
}
