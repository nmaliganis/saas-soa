using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Questions
{
  public class QuestionForCreationUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
    [Editable(true)] public int CategoryId { get; set; }
    [Editable(true)] public int PersonId { get; set; }
  }
}