using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;

namespace StudentsManagement.Models
{
    public class Student
    {
        public int Id { set; get; }
        [Display(Name="Student Name"),MaxLength(50,ErrorMessage ="The length of name should be less than 50")]
        [Required(ErrorMessage ="Please input name!")]
        public string Name { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public ClassNameEnum? ClassName { set; get; }

        public string ImagePath { set; get; }

        public string[] getImagePathUrl()
        {
            List<string> urls = new List<string>(); 
            if (this.ImagePath!=null&&this.ImagePath.Trim() != "")
            {
                var imagePaths = SpliteString(this.ImagePath, "<--|-->");
                foreach(var imagePath in imagePaths)
                {
                    urls.Add(Path.Combine("/img", imagePath));
                }
            }
            if(urls.Count==0)
            {
                urls.Add("/img/banner.jpg");
            }
            return urls.ToArray();
        }

        public string[] SpliteString(string str,string spliteCharacter)
        {
            string[] sArray = Regex.Split(str, spliteCharacter);
            return sArray;
        }
        

    }
}
