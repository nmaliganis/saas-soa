using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Categories
{
  public class CategoryForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Name { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}