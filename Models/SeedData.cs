using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProjectContext>();
            context.Database.EnsureCreated();
            if (!context.CountryItems.Any())
            {
                context.CountryItems.Add(new CountryItem
                {
                    Id = 1,
                    Name = "Great Britain"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Id = 2,
                    Name = "Poland"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Id = 3,
                    Name = "Germany"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Id = 4,
                    Name = "Spain"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Id = 5,
                    Name = "Denmark"
                });
                context.SaveChanges();
            }
        }
    }
}
