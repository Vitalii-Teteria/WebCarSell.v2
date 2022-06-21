using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebCarSell.Pages
{
    public class LoginPage : PageModel
    {
        private readonly ILogger<LoginPage> _logger;

        public LoginPage(ILogger<LoginPage> logger) 
        {
            _logger = logger;
        }

        public void OnGet() 
        {

        }
    }
}
