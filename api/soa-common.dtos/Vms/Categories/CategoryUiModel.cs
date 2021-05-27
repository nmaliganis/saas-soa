using System;
using System.ComponentModel.DataAnnotations;
using soa.common.infrastructure.Vms.Bases;

namespace soa.common.infrastructure.Vms.Categories
{
  public class CategoryUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Name { get; set; }
    [Editable(true)] public bool Active { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
