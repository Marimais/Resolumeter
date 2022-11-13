﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Resolution
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string UserName { get; set; } = string.Empty;
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public virtual List<Goal> Goals { get; set; } = default!;
        public virtual List<Dream>? Dreams { get; set; }
    }
}
