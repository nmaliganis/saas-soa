using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Tags
{
  public class TagForDeletionUiModel
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