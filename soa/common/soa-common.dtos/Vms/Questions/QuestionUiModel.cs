using System;
using System.ComponentModel.DataAnnotations;
using soa.common.dtos.Vms.Bases;

namespace soa.common.dtos.Vms.Questions
{
  public class QuestionUiModel : IUiModel
  {
    [Key] public int Id { get; set; }
    [Editable(true)] public string Message { get; set; }
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
    [Editable(true)] public int Views { get; set; }
    [Editable(true)] public int Flags { get; set; }
    [Editable(true)] public int Votes { get; set; }
    [Editable(true)] public bool Active { get; set; }
    [Editable(true)] public int CategoryId { get; set; }
    [Editable(true)] public int PersonId { get; set; }
    
    [Editable(true)] public int CountAnswers { get; set; }
    [Editable(true)] public DateTime CreatedDate { get; set; }
  }
}
