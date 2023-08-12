using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MotivWebApp.Pages
{
    public class QuotePersonalDetailsModel : PageModel
    {
        private readonly ILogger<QuotePersonalDetailsModel> _logger;

        public QuotePersonalDetailsModel(ILogger<QuotePersonalDetailsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}