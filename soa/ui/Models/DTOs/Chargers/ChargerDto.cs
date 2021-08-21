using System;
using System.Collections.Generic;
using System.Linq;
using smart.charger.webui.Models.DTOs.Sessions;

namespace smart.charger.webui.Models.DTOs.Chargers
{
  public class ChargerDto
  {
    public Guid Id { get; set; }
    public string Message { get; set; }

    public string SerialNumber { get; set; }
    public string Brand { get; set; }
    public DateTime RegisteredDate { get; set; }
    public double MaxPower { get; set; }
    public string PricePolicyRef { get; set; }
    public List<SessionDto> Sessions { get; set; }

    public int Phases { get; set; }
    public string Curves { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Ports { get; set; }

    public string Type { get; set; }


    public bool InUse
    {
      get
      {
        return Sessions.Any(x => x.StatusIndex != 3);
      }
    }
    public Guid StationId { get; set; }
    public string StationName { get; set; }
  }
}
