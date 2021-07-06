using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Tags
{
  public class TagForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Description { get; set; }
    [Editable(true)] public string Active { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}