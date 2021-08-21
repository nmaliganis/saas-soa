using System;
using System.Collections.Generic;
using smart.charger.webui.Models.DTOs.Chargers;

namespace smart.charger.webui.Store.Chargers
{
  public class ChargerState
  {
    public bool IsLoading { get; private set; }
    public string ErrorMessage { get; private set; }
    public List<ChargerDto> ChargerList { get; private set; }
    public ChargerDto Charger { get; private set; }
    public ChargerForCreationDto ChargerToBeCreatedPayload { get; private set; }
    public ChargerForModificationDto ChargerToBeUpdatePayload { get; }
    public Guid ChargerId { get; }

    public ChargerState(
      List<ChargerDto> chargerList, 
      string errorMessage, 
      bool isLoading,
      ChargerDto charger, 
      ChargerForCreationDto chargerToBeCreatedPayload, 
      ChargerForModificationDto chargerToBeUpdatePayload, 
      Guid chargerId
    )
    {
      ChargerList  = chargerList;
      ErrorMessage = errorMessage;
      IsLoading = isLoading;
      Charger = charger;
      ChargerToBeCreatedPayload = chargerToBeCreatedPayload;
      ChargerToBeUpdatePayload = chargerToBeUpdatePayload;
      ChargerId = chargerId;
    }
  }
}