using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{

    public class Goal
    {
        public Goal() 
        {
            this.Tasks= new List<Task>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
       
        [Required]
        public virtual Status Status { get; set; } = Status.Started;

        [Required]
        public virtual Resolution Resolution { get; set; }

        public IEnumerable<Task> Tasks { get; set;}
    }
}