using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Index(nameof(Name),nameof(GoalId), IsUnique = true)]
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public virtual Status Status { get; set; } = Status.Started;
        
        public int GoalId { get; set; } 

        public virtual Goal Goal { get; set; }    
    }
}
 