using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        public int AddStudent(Student student);
        public bool DeleteStudent(Student student);
        public bool UpdateStudent(Student student);
        public Student GetById(int studentId);
        public List<Student> GetAllStudents();
        public Student GetStudentDetail(int studentId);
    }
}
