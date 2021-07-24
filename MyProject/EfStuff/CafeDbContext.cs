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

        public DbSet<Order> Orders { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<DishInOrder> DishesInOrderd { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Dishes)
                .WithOne(dish => dish.Category);

            modelBuilder.Entity<Dish>()
                .HasMany(dish => dish.Prices)
                .WithOne(price => price.Dish);

            modelBuilder.Entity<User>()
                .HasMany(user => user.OrderHistory)
                .WithOne(order => order.User);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Basket)
                .WithOne(basket => basket.User)
                .HasForeignKey<Basket>(x => x.ForeignKeyUser);

            modelBuilder.Entity<Basket>()
                .HasMany(basket => basket.Dishes)
                .WithMany(dish => dish.Baskets);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.DishesInOrder)
                .WithMany(dish => dish.Orders);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
