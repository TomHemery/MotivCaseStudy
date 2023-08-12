using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MotivWebApp.Pages
{
    public class QuotePersonalDetailsModel : PageModel
    {
        private readonly ILogger<QuotePersonalDetailsModel> _logger;

        public bool ShowFinancialSection { get; private set; } = false;

        public QuotePersonalDetailsModel(ILogger<QuotePersonalDetailsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}