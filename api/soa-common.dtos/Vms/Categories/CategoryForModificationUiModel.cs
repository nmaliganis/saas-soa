using System.ComponentModel.DataAnnotations;
using soa.common.infrastructure.Vms.Bases;

namespace soa.common.infrastructure.Vms.Categories
{
  public class CategoryForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Name { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}