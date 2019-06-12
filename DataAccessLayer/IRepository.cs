using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T>:IDisposable
    {
        List<T> GetAll();
        T FindById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);

    }
}
