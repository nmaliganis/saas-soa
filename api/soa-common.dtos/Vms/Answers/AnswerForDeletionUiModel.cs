using System.ComponentModel.DataAnnotations;

namespace soa.common.infrastructure.Vms.Answers
{
  public class AnswerForDeletionUiModel
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