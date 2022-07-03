using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IGenericService<T>
    {
        Task<List<T>> TGetAllAsync();
        //Task<T> TGetById(int id);
        Task TAdd(T t);
        void TUpdate(T t);
        Task TDelete(T t);

    }
}
