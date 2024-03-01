using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0306.Models
{
    public class Tasks
    {
        [Key]
        [Required]

        public int TaskId { get; set; }

        [ForeignKey("QuadrantId")]
        [Required]
        public int QuadrantId { get; set; }
        public Quadrant Quadrants { get; set; }


        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        

        public string? DueDate { get; set; }

        public bool Completed { get; set; }
    }
}
