using DAL.Abstract;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAllPeopleWithAddress()
        {
            return await _context.People.Include(p=>p.Address).ToListAsync();
        }
    }
}
