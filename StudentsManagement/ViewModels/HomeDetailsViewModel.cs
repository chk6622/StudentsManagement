using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsManagement.Models;

namespace StudentsManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Student Student { get; set; }
        public string PageTitle { get; set; }
    }
}
