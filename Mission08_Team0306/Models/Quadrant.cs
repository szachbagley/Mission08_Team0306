using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0306.Models
{
    public class Quadrant
    {

        // Connect the quadrants table to our .NET
        [Key]
        [Required]
        public int QuadrantId { get; set; }

        public string? QuadrantDescription { get; set; }
    }
}
