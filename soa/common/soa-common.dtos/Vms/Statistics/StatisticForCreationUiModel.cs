using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Statistics
{
  public class StatisticForCreationUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
  }
}