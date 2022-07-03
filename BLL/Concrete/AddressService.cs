using BLL.Abstract;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task TAdd(Address t)
        {
            await _addressRepository.Insert(t);
        }

        public async Task TDelete(Address t)
        {
            await _addressRepository.Delete(t);
        }

        public async Task<List<Address>> TGetAllAsync()
        {
            return await _addressRepository.GetAllAsync();
        }

        public void TUpdate(Address t)
        {
            _addressRepository.Update(t);
        }
    }
}
