using System.ComponentModel.DataAnnotations;
using ms.common.dtos.Vms.Bases;

namespace ms.common.dtos.Vms.Questions
{
  public class QuestionForModificationUiModel : IUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
    [Editable(true)] public int CategoryId { get; set; }
    [Editable(true)] public int PersonId { get; set; }
    public int Id { get; set; }
    public string Message { get; set; }
  }
}