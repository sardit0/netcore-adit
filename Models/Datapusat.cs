using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventaris.Models
{
    public class Datapusat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Merek { get; set; } = string.Empty;
        public string Stock { get; set; } = string.Empty;
    }
}
