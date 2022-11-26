using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    [Index(nameof(Name), nameof(ResolutionId), IsUnique = true)]
    public class Goal
    {
        public Goal() 
        {
            this.Tasks= new List<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
       
        [Required]
        public virtual Status Status { get; set; } = Status.Started;

        public int ResolutionId { get; set; }

        public virtual Resolution Resolution { get; set; }

        public IEnumerable<Task> Tasks { get; set;}
    }
}