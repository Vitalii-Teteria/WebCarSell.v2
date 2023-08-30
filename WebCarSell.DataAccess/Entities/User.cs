using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCarSell.DataAccess.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebCarSell.DataAccess.Entities
{
    public class User : IdentityUser, ISoftDeletable
    {
        public Guid IdUser { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        public string SName { get; set; }

        public string Roles { get; set; }

        public bool IsDeleted { get; set; }
    }
}
