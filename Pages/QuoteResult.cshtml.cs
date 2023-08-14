using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Source.Products;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Pages
{
    public class QuoteResultModel : PageModel
    {
        public IFormCollection? FormResults { get; private set; } = null;

        public readonly string[] goodToppings = { "sausage", "bacon", "mushrooms", "pepperoni" };

        // Duplicating these is dirty, I know there must be a better way. :'(
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string EmailAddress { get; set; } = string.Empty;
        [BindProperty]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Topping { get; set; } = string.Empty;

        [BindProperty]
        [Required]
        [Range(0, 1000000)]
        [DataType(DataType.Currency)]
        public float Income { get; set; } = 0;
        [BindProperty]
        [Required]
        public bool ImpulseBuys { get; set; } = false;
        [BindProperty]
        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public float SillyHatSpend { get; set; } = 0;

        public bool IncomeExceedsSpend { get; private set; } = false;
        public bool PizzaToppingGood { get; private set; } = false;
        public bool IncomeMultipleOfThree { get; private set; } = false;

        public int Score { get; protected set; } = 0;
        public const int MAX_SCORE = 4;

        protected ProductRegistry _productRegistry;
        public List<FinanceProduct>? ValidFinanceProducts { get; protected set; }

        public QuoteResultModel(ProductRegistry productRegistry)
        {
            _productRegistry = productRegistry;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("./QuoteForm");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                RedirectToPage("./QuoteForm");
            }
            IncomeExceedsSpend = (Income / 12) > SillyHatSpend;
            PizzaToppingGood = goodToppings.Contains(Topping.ToLower());
            IncomeMultipleOfThree = Income % 3 == 0;
            Score = (IncomeExceedsSpend ? 1 : 0) + (PizzaToppingGood ? 1 : 0) + (IncomeMultipleOfThree ? 1 : 0) + (ImpulseBuys ? 0 : 1);
            ValidFinanceProducts = _productRegistry.GetApprovedProducts(Score);
            return Page();
        }
    }
}