using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wine { get; set; }
        public DbSet<Testing> Catas { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { 
    
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Testing>()
                .HasMany(c => c.Wines)
                .WithMany();
        }
    }
}
