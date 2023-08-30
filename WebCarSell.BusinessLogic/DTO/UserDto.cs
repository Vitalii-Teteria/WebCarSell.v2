using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBCarSell.BusinessLogic.DTO
{
    public class UserDto: IdentityUser
    {
        public Guid IdUser { get; set; }
        public string SName { get; set; }
        public string Roles { get; set; }
    }
}
