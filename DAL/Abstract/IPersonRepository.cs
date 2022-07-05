using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<List<Person>> GetAllPeopleWithAddress();
    }
}
