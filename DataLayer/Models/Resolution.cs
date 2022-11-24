using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{

    [Index(nameof(UserName), nameof(Year), IsUnique = true)]
    public class Resolution
    {
        public Resolution() 
        {
            this.Goals= new List<Goal>();
        }
        [Key]
        public int Id { get; set; }
        [Required]        
        public string UserName { get; set; } = string.Empty;
        [Required]        
        public DateTime Year { get; set; }

        public virtual IEnumerable<Goal> Goals { get; set; }
        
    }
}
