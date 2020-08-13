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
                    Price = 9.99m,
                    Calories = 1525,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 2,
                    Name = "Tied for First",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 1300,
                    Weight = 0.5m,
                    Compliment = "That tie looks great on you! Is it new?"
                },
                new Flummery
                {
                    Id = 3,
                    Name = "Tryion",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 900,
                    Weight = 0.5m,
                    Compliment = "Oh wow, you really tried your hardest on that!"
                },
                new Flummery
                {
                    Id = 4,
                    Name = "Baby Cowboy",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 912,
                    Weight = 0.5m,
                    Compliment = "That chili would be pretty spicy to an infant."
                },
                new Flummery
                {
                    Id = 5,
                    Name = "Polka",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 2100,
                    Weight = 0.5m,
                    Compliment = "Stylish if your grandparents dressed you."
                },
                new Flummery
                {
                    Id = 6,
                    Name = "Lark on the Wing",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 1792,
                    Weight = 0.5m,
                    Compliment = "What a nice sorting algorithm."
                },
                new Flummery
                {
                    Id = 7,
                    Name = "Scarce Flour",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 1135,
                    Weight = 0.5m,
                    Compliment = "Yeah, that's a nice loaf of quarantine sourdough."
                },
                new Flummery
                {
                    Id = 8,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 1280,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 9,
                    Name = "Job Jelly",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 615,
                    Weight = 0.5m,
                    Compliment = "I can't believe you managed to pull that off. Good job."
                },
                new Flummery
                {
                    Id = 10,
                    Name = "Lark on the Wing",
                    Manufacturer = "Acme Baking",
                    Price = 9.99m,
                    Calories = 1792,
                    Weight = 0.5m,
                    Compliment = "What a nice sorting algorithm."
                }
            );
        }

        public DbSet<Flummery> Flummery { get; set; }
    }
}
