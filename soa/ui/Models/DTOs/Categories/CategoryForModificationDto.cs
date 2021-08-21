using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Categories
{
  public class CategoryForModificationDto
  {
      [Editable(true)] public string Name { get; set; }
      public int Id { get; set; }
      public string Message { get; set; }
    }
}