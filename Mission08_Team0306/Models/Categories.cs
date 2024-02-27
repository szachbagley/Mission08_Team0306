using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission08_Team0306.Models
{
    public class Categories
    {
        [Key]
        [Required]

        public int CategoryId { get; set; }

        public string? CategoryDescription { get; set; }

        
    }
}
