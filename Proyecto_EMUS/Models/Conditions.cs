﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Conditions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

    }
}
