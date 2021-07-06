using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Persons
{
  public class PersonForCreationUiModel
  {
    [Editable(true)] public string Email { get; set; }
    [Editable(true)] public string Lastname { get; set; }
    [Editable(true)] public string Firstname { get; set; }
  }
}