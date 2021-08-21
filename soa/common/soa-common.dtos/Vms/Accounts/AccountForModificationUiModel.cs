using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Accounts
{
  public class AccountForModificationUiModel : IUiModel
  {
    public int Id { get; set; }
    public string Message { get; set; }
  }
}