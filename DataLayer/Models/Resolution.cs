using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Resolution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly Year { get; set; }
        [Required]
        public virtual List<Goal> Goals { get; set; } = default!;
        public virtual List<Dream>? Dreams { get; set; }
    }
}
