using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudentsManagement.Models;

namespace StudentsManagement.ViewModels
{
    public class StudentCreateViewModel
    {
        //public int Id { set; get; }
        [Display(Name = "Student Name"), MaxLength(50, ErrorMessage = "The length of name should be less than 50")]
        [Required(ErrorMessage = "Please input name!")]
        public string Name { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public ClassNameEnum? ClassName { set; get; }
        [Display(Name="Student's image")]
        public List<IFormFile> Photos { set; get; }
    }
}
