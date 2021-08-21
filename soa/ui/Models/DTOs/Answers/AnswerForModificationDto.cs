using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Answers
{
  public class AnswerForModificationDto
  {
      [Editable(true)] public string Title { get; set; }
      [Editable(true)] public string Body { get; set; }
      [Editable(true)] public int PersonId { get; set; }
      [Editable(true)] public int ParentId { get; set; }
      public int Id { get; set; }
    }
}