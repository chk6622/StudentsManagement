using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    class MyDbContext:DbContext
    {
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Product> products { set; get; }
        public DbSet<Store> Stores { set; get; }
        public DbSet<Sales> Sales { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N0AM9A1;Database=StudentManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Seed();
        //}
    }
}
