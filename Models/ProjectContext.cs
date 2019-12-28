using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public class ProjectContext : IdentityDbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }*/

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryItem>().HasData(
                new CountryItem
                {
                    Id = 1,
                    Name = "Great Britain"
                },
                new CountryItem
                {
                    Id = 2,
                    Name = "Poland"
                },
                new CountryItem
                {
                    Id = 3,
                    Name = "Germany"
                },
                new CountryItem
                {
                    Id = 4,
                    Name = "Spain"
                },
                new CountryItem
                {
                    Id = 5,
                    Name = "Denmark"
                }
            );
        }*/

        public DbSet<CarItem> CarItems { get; set; }
        public DbSet<BrandItem> BrandItems { get; set; }
        public DbSet<CountryItem> CountryItems { get; set; }
    }
}
