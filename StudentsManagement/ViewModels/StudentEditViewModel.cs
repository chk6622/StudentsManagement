using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudentsManagement.Models;

namespace StudentsManagement.ViewModels
{
    public class StudentEditViewModel:Student
    {
        public List<IFormFile> Photos { set; get; }
    }
}
