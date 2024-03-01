using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0306.Models
{
    public class Categories
    {
        // Put the data down below for the cateogories table

        [Key]
        [Required]
        public int CategoryId { get; set; }

        public string? CategoryDescription { get; set; }

        
    }
}
