using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : IGenericDal<Student>
    {
        public bool Delete(Student item)
        {
            throw new NotImplementedException();
        }

        public Student GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetListAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Student item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student item)
        {
            throw new NotImplementedException();
        }
    }
}
