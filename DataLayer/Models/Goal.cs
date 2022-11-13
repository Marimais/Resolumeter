using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public virtual Status Status { get; set; } = Status.Started;
        public virtual Resolution? Resolution { get; set; }
    }
}