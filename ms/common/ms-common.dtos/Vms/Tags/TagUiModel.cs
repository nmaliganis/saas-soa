using System;
using System.ComponentModel.DataAnnotations;
using ms.common.dtos.Vms.Bases;

namespace ms.common.dtos.Vms.Tags
{
  public class TagUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Description { get; set; }
    [Editable(true)] public bool Active { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
