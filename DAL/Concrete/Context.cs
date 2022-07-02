using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }

    }
}
