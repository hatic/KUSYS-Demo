using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            List<SelectListItem> items = courseManager.GetAllCourses().ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.CourseName,
                    Value = a.CourseId,
                    Selected = false
                };
            });
            ViewData["StudentSelectList"] = items;
            if (studentId == 0)
            {
                items.Add(new SelectListItem { Value = String.Empty, Text = "Select a course", Selected = true });
                return View(new Student());
            }
            return View(studentManager.GetById(studentId));
        }
        [HttpPost]
        public IActionResult AddUpdateStudent(Student student)
        {
            if (student.StudentId == 0)
                studentManager.AddStudent(student);
            else
                studentManager.UpdateStudent(student);
            return RedirectToAction("Index","Student");
        }
        public IActionResult ViewDetails(int studentId)
        {
            var student = studentManager.GetStudentDetail(studentId);
            return View(student);
        }


    }
}
