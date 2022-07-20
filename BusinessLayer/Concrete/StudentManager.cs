using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class StudentManager:IStudentService
    {
        IStudentDal _studentDal;
         
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public int AddStudent(Student student)
        {
           return _studentDal.Insert(student);
        }

        public bool DeleteStudent(Student student)
        {
            return _studentDal.Delete(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentDal.GetListAll();
        }

        public Student GetById(int studentId)
        {
           return _studentDal.GetByID(studentId);
        }

        public bool UpdateStudent(Student student)
        {
            return _studentDal.Update(student);
        }
        public Student GetStudentDetail(int studentId)
        {
            using var context = new Context();
            var result = context.Students
            .Include(s => s.Course)
            .Where(s => s.StudentId == studentId)
            .FirstOrDefault();
            return result;
        }
    }
}
