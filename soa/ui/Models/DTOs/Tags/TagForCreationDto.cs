using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Tags
{
  public class TagForCreationDto
  {
      [Editable(true)] public string Title { get; set; }
      [Editable(true)] public string Description { get; set; }
    }
}