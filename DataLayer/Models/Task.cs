﻿using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public virtual Status Status { get; set; } = Status.Started;
    }
}
