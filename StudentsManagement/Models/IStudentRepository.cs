using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentsManagement.Models
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);

        IEnumerable<Student> GetAllStudents();

        Student add(Student student);

        /// <summary>
        ///     update student information
        /// </summary>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        Student Update(Student updateStudent);

        /// <summary>
        ///     delete student information
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student Delete(int id);

    }
}
