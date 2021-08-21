using System;

namespace soa.ui.Models.DTOs.Answers
{
  public class AnswerForDeletionDto
  {
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool DeletionStatus { get; set; }
    public string Message { get; set; }
  }
}