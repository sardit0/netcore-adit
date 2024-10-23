using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventaris.Models;

namespace Inventaris.Data
{
    public class InventarisContext : DbContext
    {
        public InventarisContext (DbContextOptions<InventarisContext> options)
            : base(options)
        {
        }

        public DbSet<Inventaris.Models.Item> Item { get; set; } = default!;
        public DbSet<Inventaris.Models.Category> Category { get; set; } = default!;
        public DbSet<Inventaris.Models.Supplier> Supplier { get; set; } = default!;
    }
}
