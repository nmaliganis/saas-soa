using System.ComponentModel.DataAnnotations;
using ms.common.dtos.Vms.Bases;

namespace ms.common.dtos.Vms.Categories
{
  public class CategoryForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Name { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}