using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSON_Serializer.Controllers
{
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _personService.TGetAllAsync();
        }

        //[HttpPost]
        //public async Task<ActionResult<Person>> CreatePerson(Person person)
        //{
        //    await _personService.TAdd(person);
        //    return NoContent();
        //}
    
        [HttpPost]
        public async Task<ActionResult<long>> CreatePersonFromJson([FromBody]string json)
        {
            return await _personService.Save(json);
        }
    
    }
}
