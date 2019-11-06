using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test1
            //string str = "bb0d857e-645b-4c5c-8e1c-bfcecd290fe5_LEGO®-Ideas-Wall-E-21303.jpg<--|-->1bcc13e7-a538-4406-b4aa-785b539a9859_LEGO®-Ideas-Wall-E-21303_v1.jpg<--|-->8828730f-4574-4e9e-9b81-a9b6a8759e41_LEGO®-Ideas-Wall-E-21303_v2.jpg";
            //string spliteCharacter = "<--|-->";
            //string[] results = Program.SpliteString(str, spliteCharacter);
            //foreach (var item in results)
            //{
            //    Console.WriteLine(item);
            //}
            //One one = new One() { Id = 1, Name = "Tom", Age = 5 };
            //Two two = Program.Mapper<Two, One>(one);
            //two.print();
            //two.Id = 2;
            //two.Name = "Mary";
            //two.Age = 6;
            //two.Gender = "famale";
            //Program.MapperToModel<One, Two>(one, two);
            //one.print();
            //int p = 5;
            //string str=String.Format("123{0}",p);
            //Console.WriteLine(str);
            #endregion
            MyDbContext dbContext = new MyDbContext();
            #region add a customer
            Customer c1 = new Customer()
            {
                Name = "Tom",
                Address = "Queen Street",
            };
            //dbContext.Add<Customer>(c1);
            //dbContext.SaveChanges();
            #endregion
            #region query edit delete customer
            //Customer c1 =dbContext.Customers.Find(1);
            //Console.WriteLine("{0},{1}",c1.Name,c1.Address);
            //c1.Address = "North shore";
            //var customer = dbContext.Customers.Attach(c1);
            //customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //dbContext.SaveChanges();
            //c1 = dbContext.Customers.Find(1);
            //Console.WriteLine("{0},{1}", c1.Name, c1.Address);
            //dbContext.Remove(c1);
            //dbContext.SaveChanges();
            //c1 = dbContext.Customers.Find(1);
            //if (c1 == null)
            //{
            //    Console.WriteLine("The customer has been deleted!");
            //}
            #endregion
            #region add Sales
            //Sales sale = new Sales()
            //{
            //    Customer = c1,
            //    DateSold = "2019-11-5",
            //};
            //dbContext.Add<Sales>(sale);
            //dbContext.SaveChanges();
            #endregion
            Sales sale = dbContext.Sales.Include(x => x.Customer).First(x => x.Customer.Id == 2);
            c1 = sale.Customer;
            Console.WriteLine("{0},{1}", c1.Name, c1.Address);
            //c1.Name = "Mary";
            //sale.DateSold = "2019-11-6";
            //dbContext.SaveChanges();


        }
        public static string[] SpliteString(string str, string spliteCharacter)
        {
            string[] sArray = Regex.Split(str, spliteCharacter);
            //foreach (var item in sarray)
            //{
            //    console.writeline(item);
            //}
            return sArray;
        }


        /// Copy the same name proporties between two object by reflection
        /// The function create a new object
        /// </summary>
        /// <typeparam name="D">destination object class</typeparam>
        /// <typeparam name="S">source object class</typeparam>
        /// <param name="s">source object</param>
        /// <returns>destination object</returns>
        public static D Mapper<D, S>(S s)
        {
            D d = Activator.CreateInstance<D>(); //create a new instance
            try
            {
                var Types = s.GetType();//get the class of source  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//get proporties of source class  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//determine if the properties's name is the same   
                        {
                            dp.SetValue(d, sp.GetValue(s, null), null);//copy the value of source object properties to the destination object
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return d;
        }

        /// <summary>
        /// Copy the same name proporties between two object by reflection
        /// The function does not create the new object
        /// </summary>
        /// <typeparam name="D">destination object class</typeparam>
        /// <typeparam name="S">source object class</typeparam>
        /// <param name="s">source object</param>
        /// <returns>destination object</returns>
        /// <returns></returns>
        public static void MapperToModel<D, S>(D d, S s)
        {
            try
            {
                var Types = s.GetType();//get the class of source  
                var Typed = typeof(D);
                foreach (PropertyInfo sp in Types.GetProperties())//get proporties of source class  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//determine if the properties's name is the same   
                        {
                            dp.SetValue(d, sp.GetValue(s, null), null);//copy the value of source object properties to the destination object
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    class One
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }

        public void print()
        {
            Console.WriteLine("Id={0}\nName={1}\nAge={2}",Id,Name,Age);
        }
    }

    class Two:One
    {
        public string Gender { set; get; }

        public void print()
        {
            base.print();
            Console.WriteLine("Gender={0}", Gender);
        }
    }
}
