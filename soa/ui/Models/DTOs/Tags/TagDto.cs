using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Tags
{
    public class TagDto
    {
        public TagDto()
        {

        }

        [Key] public int Id { get; set; }
        [Editable(true)] public string Message { get; set; }
        [Editable(true)] public string Title { get; set; }
        [Editable(true)] public string Description { get; set; }
        [Editable(true)] public int Count { get; set; }
        [Editable(true)] public bool Active { get; set; }
        [Editable(true)] public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
