using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Tags
{
  public class TagForCreationUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Description { get; set; }
  }
}