using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _students;
        public MockStudentRepository()
        {
            _students = new List<Student>()
            {
                new Student(){Id=1,Name="Tom",ClassName=ClassNameEnum.FirstGrade,Email="abc@sina.com"},
                new Student(){Id=2,Name="Mary",ClassName=ClassNameEnum.SecondGrade,Email="xxx@gmail.com"}
            };
        }

        public Student add(Student student)
        {
            student.Id=_students.Max(s=>s.Id)+1;
            _students.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student student = _students.FirstOrDefault(a => a.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            Student student =_students.FirstOrDefault(a => a.Id == id);

            return student;
        }

        public Student Update(Student updateStudent)
        {
            Student student = _students.FirstOrDefault(a => a.Id == updateStudent.Id);

            if(student!=null)
            {
                student.Name = updateStudent.Name;
                student.Email = updateStudent.Email;
                student.ClassName = updateStudent.ClassName;
            }
            return student;
        }
    }
}
