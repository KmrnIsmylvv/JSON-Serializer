using BLL.Abstract;
using BLL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSON_Serializer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            return await _addressService.TGetAllAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Address>> CreateAddress(Address address)
        {
             await _addressService.TAdd(address);
            return NoContent();
        }
    }
}
