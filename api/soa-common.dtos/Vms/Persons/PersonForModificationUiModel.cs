using System.ComponentModel.DataAnnotations;
using soa.common.infrastructure.Vms.Bases;

namespace soa.common.infrastructure.Vms.Persons
{
  public class PersonForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Email { get; set; }
    [Editable(true)] public string Lastname { get; set; }
    [Editable(true)] public string Firstname { get; set; }
    
    [Editable(true)] public bool AddFlaged { get; set; }
    [Editable(true)] public bool AddVoted { get; set; }
    [Editable(true)] public bool RemoveFlaged { get; set; }
    [Editable(true)] public bool RemoveVoted { get; set; }
    [Editable(true)] public bool Active { get; set; }
    [Key]
    public int Id { get; set; }
    public string Message { get; set; }
  }
}