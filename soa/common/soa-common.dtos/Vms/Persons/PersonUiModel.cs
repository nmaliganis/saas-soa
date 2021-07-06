using System;
using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Persons
{
  public class PersonUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Email { get; set; }
    [Editable(true)] public string Lastname { get; set; }
    [Editable(true)] public string Firstname { get; set; }
    [Editable(true)] public int Flaged { get; set; }
    [Editable(true)] public int Voted { get; set; }
    [Editable(true)] public bool Active { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
