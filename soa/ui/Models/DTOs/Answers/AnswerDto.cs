using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Answers
{
    public class AnswerDto
    {
        public AnswerDto()
        {

        }

        [Key] public int Id { get; set; }
        [Editable(true)] public string Message { get; set; }
        [Editable(true)] public string Title { get; set; }
        [Editable(true)] public string Body { get; set; }
        [Editable(true)] public int Views { get; set; }
        [Editable(true)] public int Flags { get; set; }
        [Editable(true)] public int Votes { get; set; }
        [Editable(true)] public bool Active { get; set; }
        [Editable(true)] public int ParentId { get; set; }
        [Editable(true)] public int PersonId { get; set; }
        [Editable(true)] public DateTime CreatedDate { get; set; }
    }
}
