using BusinessLayer.Concrete;
using BusinessLayer.ValidationRoles;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager(new EfStudentRepository());
        CourseManager courseManager = new CourseManager(new EfCourseRepository());
        public IActionResult Index()
        {
            var students = studentManager.GetAllStudents();
            return View(students);
        }
        public IActionResult DeleteStudent(int Id)
        {
            var student = studentManager.GetById(Id);
            var result = studentManager.DeleteStudent(student);
            return RedirectToAction("Index", "Student");
        }
        [HttpGet]
        public IActionResult AddUpdateStudent(int studentId)
        {
            ViewData["StudentSelectList"] = GetCourses(studentId);
            if (studentId == 0)
                return View(new Student());
            return View(studentManager.GetById(studentId));
        }
        [HttpPost]
        public IActionResult AddUpdateStudent(Student student)
        {
            StudentValidator validator = new StudentValidator();
            ValidationResult result = validator.Validate(student);
            if (result.IsValid)
            {
                if (student.StudentId == 0)
                    studentManager.AddStudent(student);
                else
                    studentManager.UpdateStudent(student);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewData["StudentSelectList"] = GetCourses(student.StudentId);
                return View(student);
            }
            return RedirectToAction("Index", "Student");
        }
        public IActionResult ViewDetails(int studentId)
        {
            var student = studentManager.GetStudentDetail(studentId);
            return View(student);
        }
        private List<SelectListItem> GetCourses(int studentId)
        {
            List<SelectListItem> items = courseManager.GetAllCourses().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.CourseName,
                    Value = a.CourseId,
                    Selected = false
                };
            });
            if (studentId == 0)
                items.Add(new SelectListItem { Value = String.Empty, Text = "Select a course", Selected = true });
            return items;
        }

    }
}
