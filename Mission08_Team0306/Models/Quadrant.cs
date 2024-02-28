using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0306.Models
{
    public class Quadrant
    {


        [Key]
        [Required]
        public int QuadrantId { get; set; }

        public string? QuadrantDescription { get; set; }
    }
}
