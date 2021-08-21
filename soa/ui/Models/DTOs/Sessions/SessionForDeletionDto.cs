using System;

namespace smart.charger.webui.Models.DTOs.Sessions
{
  public class SessionForDeletionDto
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}