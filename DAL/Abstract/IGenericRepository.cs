using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IGenericRepository<T>
    {
        Task Insert(T t);
        void Update(T t);
        Task Delete(T t);
        Task<List<T>> GetAll();
    }
}
