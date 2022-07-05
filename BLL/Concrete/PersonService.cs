using BLL.Abstract;
using BLL.Services;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<long> Save(string json)
        {
           Person person = JsonConverter.Deserialize<Person>(json);

           await TAdd(person);

            return person.Id;
        }

        public async Task TAdd(Person t)
        {
            await _personRepository.Insert(t);
        }

        public async Task TDelete(Person t)
        {
            await _personRepository.Delete(t);
        }

        public async Task<List<Person>> TGetAllAsync()
        {
            return await _personRepository.GetAllPeopleWithAddress();
        }

        public void TUpdate(Person t)
        {
            _personRepository.Update(t);
        }
   
         
    }
}
