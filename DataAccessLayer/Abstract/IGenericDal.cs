using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T:class
    {
        int Insert(T item);
        bool Update(T item);
        bool Delete(T item);
        List<T> GetListAll();
        T GetByID(int id);
    }
}
