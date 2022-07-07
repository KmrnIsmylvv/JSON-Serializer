using BLL.Abstract;
using BLL.DTOs;
using BLL.Services;
using DAL.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> GetAll(GetAllRequest request)
        {
            List<Person> people = await TGetAllAsync();

            List<Person> filteredPeople = people
                .Where(p => p.Address.City == request.City
                        || p.FirstName == request.FirstName
                        || p.LastName == request.LastName).ToList();

            var peopleJson = JsonConverter.Serialize(filteredPeople);

            return peopleJson;
        }

        public async Task<long> Save(string json)
        {
            Person person = new Person();
            Address address = new Address();

            person = JsonConverter.Deserialize<Person>(json, person);
            address = JsonConverter.Deserialize<Address>(json, address);

            person.Address = address;

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
