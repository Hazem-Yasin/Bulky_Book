﻿using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Thriller", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Drama", DisplayOrder = 6 },
                new Category { Id = 7, Name = "Romance", DisplayOrder = 7 }
                );
        }
    }
}
