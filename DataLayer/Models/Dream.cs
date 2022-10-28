using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Dream
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
