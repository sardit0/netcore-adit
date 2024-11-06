using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventaris.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Inventaris.Data
{
    public class InventarisContext : IdentityDbContext
    {
        public InventarisContext(DbContextOptions<InventarisContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Item { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Supplier> Supplier { get; set; } = default!;
    }
}
