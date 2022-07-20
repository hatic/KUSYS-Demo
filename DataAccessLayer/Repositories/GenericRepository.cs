using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public bool Delete(T item)
        {
            using var context = new Context();
            context.Remove(item);
            int result=context.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        public T GetByID(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public int Insert(T item)
        {
            using var context = new Context();
            context.Add(item);
            return context.SaveChanges();
        }

        public bool Update(T item)
        {
            using var context = new Context();
            context.Update(item);
            var result=context.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }
    }
}
