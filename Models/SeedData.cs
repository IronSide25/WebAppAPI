using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public enum Roles
    {
        Administrator,
        User
    }

    public static class SeedData
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ProjectContext>();
            RoleManager<IdentityRole> roleManager = context.GetService<RoleManager<IdentityRole>>();
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProjectContext>();
            context.Database.EnsureCreated();
            if (!context.CountryItems.Any())
            {
                context.CountryItems.Add(new CountryItem
                {
                    Name = "Great Britain"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Name = "Poland"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Name = "Germany"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Name = "Spain"
                });
                context.CountryItems.Add(new CountryItem
                {
                    Name = "Denmark"
                });
                context.SaveChanges();
            }            
        }
    }
}
