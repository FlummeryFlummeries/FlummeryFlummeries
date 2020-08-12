using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_App.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Flummery>().HasData(
                new Flummery
                {
                    Id = 1,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 2,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 3,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 4,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 5,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 6,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 7,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 8,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 9,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 10,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Calories = 3000,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                }
            );
        }

        public DbSet<Flummery> Flummery { get; set; }
    }
}
