using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fanap.Plus.Product_Management.Models;

namespace Fanap.Plus.Product_Management.Models
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Fanap.Plus.Product_Management.Models.Products> Products { get; set; }

        public DbSet<Fanap.Plus.Product_Management.Models.Teams> Teams { get; set; }

        public DbSet<Fanap.Plus.Product_Management.Models.Members> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamAssignment>()
                .HasKey(a => new { a.TeamId, a.ProductId});

            base.OnModelCreating(modelBuilder);

        }
    }


}
