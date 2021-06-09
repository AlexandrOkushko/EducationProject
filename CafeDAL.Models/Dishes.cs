﻿using CafeDAL.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace CafeDAL.Models
{
    public partial class Dishes : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required] 
        public bool IsActual { get; set; }
    }
}