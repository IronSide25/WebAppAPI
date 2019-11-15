using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<CarItem> CarItems { get; set; }
        public DbSet<BrandItem> BrandItems { get; set; }

        public DbSet<CountryItem> CountryItems { get; set; }
    }
}
