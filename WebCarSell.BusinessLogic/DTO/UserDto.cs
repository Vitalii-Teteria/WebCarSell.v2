using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBCarSell.BusinessLogic.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SName { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
