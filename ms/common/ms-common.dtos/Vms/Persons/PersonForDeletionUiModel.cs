using System.ComponentModel.DataAnnotations;

namespace ms.common.dtos.Vms.Persons
{
  public class PersonForDeletionUiModel
  {
    [Required]
    [Editable(true)]
    public int Id { get; set; }
    [Required]
    [Editable(true)]
    public bool IsActive { get; set; }
    [Required]
    [Editable(true)]
    public bool DeletionStatus { get; set; }
    [Required]
    [Editable(true)]
    public string Message { get; set; }
  }
}