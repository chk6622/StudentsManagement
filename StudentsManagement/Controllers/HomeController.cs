using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagement.Models;
using StudentsManagement.ViewModels;
using StudentsManagement.Utils;

namespace StudentsManagement.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository=null;
        private readonly HostingEnvironment _hostingEnvironment = null;

        public HomeController(IStudentRepository studentRepository,HostingEnvironment hostingEnvironment)
        {
            this._studentRepository = studentRepository;
            this._hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            return View(students);
            //return Json(new {id="1",name="Tom" });
        }

        public IActionResult Details(int id=1)
        {
            Student model = _studentRepository.GetStudent(id);

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = model,
                PageTitle="Student Details"
                
            };

            return View(homeDetailsViewModel);
        }

        public IActionResult Edit(int id = 1)
        {
            Student student = _studentRepository.GetStudent(id);
            StudentEditViewModel studentEditViewModel = null;
            if (student != null)
            {
                studentEditViewModel = AppUtils.Mapper<StudentEditViewModel,Student>(student);
                
            }
            if(studentEditViewModel!=null)
            {
                return View(studentEditViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult Update(StudentEditViewModel model)
        {
            Student student = AppUtils.Mapper<Student, StudentEditViewModel>(model);
            List<string> uniqueFileNames = new List<string>();
            if (model.Photos != null && model.Photos.Count > 0)
            {
                string uploadFolder = Path.Combine(this._hostingEnvironment.WebRootPath, "img");
                foreach (IFormFile photo in model.Photos)
                {
                    string[] imgPath = photo.FileName.Split(new char[2] { '\\', '/' });
                    string fileName = imgPath[imgPath.Length - 1];
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    uniqueFileNames.Add(uniqueFileName);
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                uniqueFileNames.Add(student.ImagePath);
                student.ImagePath = string.Join("<--|-->", uniqueFileNames.ToArray());
            }
            this._studentRepository.Update(student);
            return RedirectToAction("Edit",new { Id=student.Id});
        }
        [HttpGet]
        public IActionResult Delete(int id=0)
        {
            if(id!=0)
            {
                Student model = _studentRepository.Delete(id);
                ViewBag.message = "Delete "+model.Name+" successfully!";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreateViewModel model)
        {
            List<string> uniqueFileNames = new List<string>();
            if (model.Photos!=null&&model.Photos.Count>0)
            {
                string uploadFolder = Path.Combine(this._hostingEnvironment.WebRootPath, "img");
                foreach (IFormFile photo in model.Photos)
                {
                    string[] imgPath = photo.FileName.Split(new char[2] { '\\', '/' });
                    string fileName = imgPath[imgPath.Length - 1];
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    uniqueFileNames.Add(uniqueFileName);
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                
            }

            Student newStudent = new Student
            {
                Name = model.Name,
                Email = model.Email,
                ClassName = model.ClassName,
                ImagePath = string.Join("<--|-->",uniqueFileNames.ToArray())
            };
            this._studentRepository.add(newStudent);
            return View();
        }
    }
}