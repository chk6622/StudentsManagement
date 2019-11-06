using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Customer c1 = new Customer()
            {
                Id = -1,
                Name = "Tom",
                Address = "Queen Street",
            };
        Product p1 = new Product()
        {
                Id = -2,
                Name = "Cup",
                Price = 26.5,
            };
            Store s1 = new Store()
            {
                Id=-3,
                Name = "Xxx warehouse",
                Address = "Mount Albert",
            };
            Sales sale1 = new Sales()
            {
                Id=-4,
                DateSold = "2019-11-5",
            };
            sale1.Customer = c1;
            sale1.Product = p1;
            sale1.Store = s1;
            //c1.ProductSold.Add(sale1);
            //p1.ProductSold.Add(sale1);
            //s1.ProductSold.Add(sale1);
            


            modelBuilder.Entity<Sales>().HasData(sale1);
            modelBuilder.Entity<Customer>().HasData(c1);
            modelBuilder.Entity<Product>().HasData(p1);
            modelBuilder.Entity<Store>().HasData(s1);
            
        }
    }
}
