using Microsoft.EntityFrameworkCore;
using MyProject.EfStuff.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.EfStuff
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Rewiews { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Dishes)
                .WithOne(dish => dish.Category);

            modelBuilder.Entity<Dish>()
                .HasMany(dish => dish.Prices)
                .WithOne(price => price.Dish);
        }
    }
}
