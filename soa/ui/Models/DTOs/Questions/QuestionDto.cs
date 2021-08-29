using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Questions
{
    public class QuestionDto
    {
        public QuestionDto()
        {

        }

        [Key] public int Id { get; set; }
        [Editable(true)] public string Message { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Editable(true)] public string Title { get; set; }
        [Required(ErrorMessage = "Body is required")]
        [Editable(true)] public string Body { get; set; }
        [Editable(true)] public int Views { get; set; }
        [Editable(true)] public int Flags { get; set; }
        [Editable(true)] public int Votes { get; set; }
        [Editable(true)] public bool Active { get; set; }
        [Editable(true)] public string Category { get; set; }
        [Editable(true)] public int CategoryId { get; set; }
        [Editable(true)] public int PersonId { get; set; }
        [Editable(true)] public DateTime CreatedDate { get; set; }
    }
}
