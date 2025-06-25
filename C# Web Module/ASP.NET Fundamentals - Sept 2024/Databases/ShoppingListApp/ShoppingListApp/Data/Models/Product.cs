﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models
{
    [Comment("Shopping List Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
