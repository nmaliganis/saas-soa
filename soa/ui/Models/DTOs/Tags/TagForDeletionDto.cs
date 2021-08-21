using System;

namespace soa.ui.Models.DTOs.Tags
{
  public class TagForDeletionDto
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}