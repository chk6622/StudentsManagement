using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManagement.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context = null;
        public SQLStudentRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Student add(Student student)
        {
            this._context.Students.Add(student);
            this._context.SaveChanges();
            return student;
        }

        public Student Delete(int id)
        {
            Student student=this._context.Students.Find(id);
            if (student != null)
            {
                this._context.Students.Remove(student);
                this._context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return this._context.Students;
        }

        public Student GetStudent(int id)
        {
            return this._context.Students.Find(id);
        }

        public Student Update(Student updateStudent)
        {
            var student = this._context.Students.Attach(updateStudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
            return updateStudent;
        }
    }
}
