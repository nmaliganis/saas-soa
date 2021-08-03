using System;
using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Accounts
{
  public class AccountUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Username { get; set; }
    [Editable(true)] public string Password { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
