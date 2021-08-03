using System;
using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Statistics
{
  public class StatisticUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
