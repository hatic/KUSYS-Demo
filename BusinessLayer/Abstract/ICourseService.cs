using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICourseService
    {
        public int AddCourse(Course course);
        public bool DeleteCourse(Course course);
        public bool UpdateCourse(Course course);
        public Course GetById(int courseId);
        public List<Course> GetAllCourses();
    }
}
