using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Models;

namespace StudentsManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public string DataList(Student student)
        {
            return "This is department->dataList"+student.Id;
        }
    }
}