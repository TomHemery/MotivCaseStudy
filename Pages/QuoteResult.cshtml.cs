using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;
using MotivWebApp.Services.Products;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Pages
{
    public class QuoteResultModel : PageModel
    {
        [BindProperty]
        [Required]
        public QuoteRequest? QuoteRequest { get; set; }

        public IFormCollection? FormResults { get; private set; } = null;

        public readonly string[] goodToppings = { "sausage", "bacon", "mushrooms", "pepperoni" };

        public bool IncomeExceedsSpend { get; private set; } = false;
        public bool PizzaToppingGood { get; private set; } = false;
        public bool IncomeMultipleOfThree { get; private set; } = false;

        public int Score { get; protected set; } = 0;
        public const int MAX_SCORE = 4;

        protected ProductRegistry _productRegistry;
        public List<FinanceProduct>? ValidFinanceProducts { get; protected set; }

        private readonly Data.MotivWebAppContext _context;

        public QuoteResultModel(ProductRegistry productRegistry, Data.MotivWebAppContext context)
        {
            _productRegistry = productRegistry;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("./QuoteForm");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (QuoteRequest == null || !ModelState.IsValid) {
                return RedirectToPage("./QuoteForm");
            }

            IncomeExceedsSpend = (QuoteRequest.Income / 12) > QuoteRequest.SillyHatSpend;
            PizzaToppingGood = goodToppings.Contains(QuoteRequest.Topping.ToLower());
            IncomeMultipleOfThree = QuoteRequest.Income % 3 == 0;
            Score = (IncomeExceedsSpend ? 1 : 0) + (PizzaToppingGood ? 1 : 0) + (IncomeMultipleOfThree ? 1 : 0) + (QuoteRequest.ImpulseBuys ? 0 : 1);

            _context.QuoteRequest.Add(QuoteRequest);
            await _context.SaveChangesAsync();

            ValidFinanceProducts = _productRegistry.GetApprovedProducts(Score);
            return Page();
        }
    }
}