using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotivWebApp.Data;
using MotivWebApp.Models;

namespace MotivWebApp.Pages.Quote
{
    public class QuoteFormModel : PageModel
    {
        private readonly MotivWebApp.Data.MotivWebAppContext _context;

        public QuoteFormModel(MotivWebApp.Data.MotivWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public QuoteRequest QuoteRequest { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.QuoteRequest == null || QuoteRequest == null)
            {
                return Page();
            }

            _context.QuoteRequest.Add(QuoteRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
