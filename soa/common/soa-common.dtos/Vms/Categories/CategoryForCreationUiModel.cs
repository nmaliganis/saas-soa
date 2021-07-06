using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Categories
{
  public class CategoryForCreationUiModel
  {
    [Editable(true)] public string Name { get; set; }
  }
}