using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Address
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public IEnumerable<Person> People { get; set; }

        
    }
}
