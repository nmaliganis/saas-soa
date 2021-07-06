using System.ComponentModel.DataAnnotations;

namespace ms.common.dtos.Vms.Categories
{
  public class CategoryForCreationUiModel
  {
    [Editable(true)] public string Name { get; set; }
  }
}