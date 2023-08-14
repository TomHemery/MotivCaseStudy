using Microsoft.AspNetCore.Mvc;
using MotivWebApp.Source.Products;

namespace MotivWebApp.Pages
{
    public class QuoteResultModel : QuoteFormModel
    {
        public IFormCollection? FormResults { get; private set; } = null;

        public readonly string[] goodToppings = { "sausage", "bacon", "mushrooms", "pepperoni" };

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