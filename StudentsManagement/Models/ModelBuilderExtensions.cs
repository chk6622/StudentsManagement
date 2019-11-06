using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentsManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Tom",
                    ClassName = ClassNameEnum.FirstGrade,
                    Email = "xxx@sina.com",

                },
                new Student()
                {
                    Id = 2,
                    Name = "Kate",
                    ClassName = ClassNameEnum.SecondGrade,
                    Email = "yyy@hotmail.com",

                },
                new Student()
                {
                    Id = 3,
                    Name = "Jane",
                    ClassName = ClassNameEnum.GradeThree,
                    Email = "kkk@gmail.com",

                }

                );
        }
    }
}
