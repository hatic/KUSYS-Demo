using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager(new EfCourseRepository());
        public IActionResult Index()
        {
            var students = courseManager.GetStudentCourses();
            return View(students);
        }
    }
}
