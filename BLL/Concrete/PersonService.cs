using AutoMapper;
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
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<string> GetAll(GetAllRequest request)
        {
            List<Person> people = await TGetAllAsync();

            var mapping = _mapper.Map<Person>(request);

            var filterPeople = people.FirstOrDefault(item => item == mapping);

            //GetAllRequest filterPeople = _mapper.Map<GetAllRequest>(people);

            string peopleJson = JsonConverter.Serialize(filterPeople);

            return peopleJson;
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
