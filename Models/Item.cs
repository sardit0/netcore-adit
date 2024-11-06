using System;
using System.ComponentModel.DataAnnotations.Schema; 
namespace Inventaris.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        
        public string Description { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //relasi ka kategroi
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //relasi ka upplier
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

    }
}
