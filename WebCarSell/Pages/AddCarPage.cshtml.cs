using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebCarSell.Pages
{
    public class AddCarPage : PageModel

    {
        private readonly ILogger<AddCarPage> _logger;

        public AddCarPage(ILogger<AddCarPage> logger) 
        {
            _logger = logger;
        }

        public void OnGet() 
        {

        }
    }
}
