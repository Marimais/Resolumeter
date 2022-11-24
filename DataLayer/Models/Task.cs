using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{    
    public class Task
    {
        [Required]
        [StringLength(100)]
        [Key]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public virtual Status Status { get; set; } = Status.Started;
        [Required]
        public virtual Goal Goal { get; set; }    
    }
}
 