﻿using System.ComponentModel.DataAnnotations;

namespace ms.common.dtos.Vms.Questions
{
  public class QuestionForDeletionUiModel
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