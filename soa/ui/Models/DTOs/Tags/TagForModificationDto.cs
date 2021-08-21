using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Tags
{
  public class TagForModificationDto
  {
      [Editable(true)] public string Title { get; set; }
      [Editable(true)] public string Description { get; set; }
      [Editable(true)] public string Active { get; set; }
      public int Id { get; set; }
      public string Message { get; set; }
    }
}