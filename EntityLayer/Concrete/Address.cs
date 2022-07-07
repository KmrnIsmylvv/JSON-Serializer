using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EntityLayer.Concrete
{
    [DataContract(IsReference = false)]
    public class Address
    {
        public long Id { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }

        public IEnumerable<Person> People { get; set; }

        
    }
}
