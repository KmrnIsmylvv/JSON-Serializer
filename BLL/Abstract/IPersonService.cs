using BLL.DTOs;
using EntityLayer.Concrete;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IPersonService : IGenericService<Person>
    {
        Task<long> Save(string json);
        Task<string> GetAll(GetAllRequest request);
    }
}
