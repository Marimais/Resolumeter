using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{

    [Index(nameof(UserName), nameof(Year), IsUnique = true)]
    public class Resolution
    {
        public Resolution()
        {
            this.Goals = new List<Goal>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [Range(2022, 2099)]
        public int Year { get; set; }

        public virtual IEnumerable<Goal> Goals { get; set; }

    }
}
