using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public int AddCourse(Course course)
        {
            return _courseDal.Insert(course);
        }
        public bool DeleteCourse(Course course)
        {
            return _courseDal.Delete(course);
        }
        public List<Course> GetAllCourses()
        {
            return _courseDal.GetListAll();
        }
        public Course GetById(int courseId)
        {
            return _courseDal.GetByID(courseId);
        }
        public bool UpdateCourse(Course course)
        {
            return _courseDal.Update(course);
        }
        public List<Student> GetStudentCourses()
        {
            using var context = new Context();
            var result = context.Students
            .Include(s => s.Course)
            .AsNoTracking()
            .ToList();
            return result;
        }
    }
}
