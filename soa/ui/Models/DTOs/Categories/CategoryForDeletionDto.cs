using System;

namespace soa.ui.Models.DTOs.Categories
{
  public class CategoryForDeletionDto
  {
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}