using DAL.Abstract;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Delete(T t)
        {
            _context.Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task Insert(T t)
        {
            await _context.AddAsync(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
