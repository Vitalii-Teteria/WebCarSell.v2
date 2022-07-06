using Microsoft.AspNetCore.Identity;

namespace WebCarSell.Models
{
    public class UserViewModel :IdentityUser
    {
        public string? SName { get; set; }
    }
}
