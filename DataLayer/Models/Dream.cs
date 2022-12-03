using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    [Index(nameof(Name),nameof(UserName),IsUnique =true)]
    public class Dream
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
    }
}
