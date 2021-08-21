using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Accounts
{
  public class AccountForCreationUiModel
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}