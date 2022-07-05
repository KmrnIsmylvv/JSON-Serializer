using BLL.Abstract;
using BLL.Concrete;
using DAL.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSON_Serializer.Controllers
{
    public class AddressController : BaseApiController
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
