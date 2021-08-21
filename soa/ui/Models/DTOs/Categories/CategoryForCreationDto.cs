using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Categories
{
  public class CategoryForCreationDto
  {
      [Editable(true)] public string Name { get; set; }
    }
}