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
                    Manufacturer = "Flum & Co",
                    Price = 72.99m,
                    Calories = 1150,
                    Weight = 0.6m,
                    Compliment = "That tie looks great on you! Is it new?"
                },
                new Flummery
                {
                    Id = 3,
                    Name = "Tryion",
                    Manufacturer = "Flippery Flumstons",
                    Price = 46.33m,
                    Calories = 873,
                    Weight = 0.7m,
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
                    Manufacturer = "Flippery Flumstons",
                    Price = 9.99m,
                    Calories = 2100,
                    Weight = 0.5m,
                    Compliment = "Stylish if your grandparents dressed you."
                },
                new Flummery
                {
                    Id = 6,
                    Name = "Lark on the Wing",
                    Manufacturer = "Full On Flummery",
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
                    Name = "Flum Jr.",
                    Manufacturer = "Flum For Kids",
                    Price = 4.99m,
                    Calories = 465,
                    Weight = 0.2m,
                    Compliment = "What a nice painting! It's going right on the fridge."
                },
                new Flummery
                {
                    Id = 9,
                    Name = "Political HumFlummery",
                    Manufacturer = "Local Government",
                    Price = 52.99m,
                    Calories = 1325,
                    Weight = 0.1m,
                    Compliment = "You all are the hardworking, salt of the earth type."
                },
                new Flummery
                {
                    Id = 10,
                    Name = "Flawmery",
                    Manufacturer = "Flumm Board for Ethical Flumming",
                    Price = 9.99m,
                    Calories = 1792,
                    Weight = 0.5m,
                    Compliment = "You're so good at arguing, you should be a lawyer."
                }
            );
        }

        public DbSet<Flummery> Flummery { get; set; }
    }
}
