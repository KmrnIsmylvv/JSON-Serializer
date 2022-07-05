using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GetAllRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
