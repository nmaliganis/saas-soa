using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Statistics
{
  public class StatisticForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Body { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}