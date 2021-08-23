using System;
using System.ComponentModel.DataAnnotations;

namespace soa.ui.Models.DTOs.Categories
{
    public class CategoryDto
    {
        public CategoryDto()
        {
        }

        [Key] public int Id { get; set; }
        [Editable(true)] public string Message { get; set; }
        [Editable(true)] public string Name { get; set; }
        [Editable(true)] public int Count { get; set; } = 0;
        [Editable(true)] public bool Active { get; set; }
        [Editable(true)] public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
