using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Pages
{
    public class QuoteFormModel : PageModel
    {
        public QuoteRequest QuoteRequest { get; set; }
    
        public QuoteFormModel() { 
            QuoteRequest = new QuoteRequest();
        }
    }
}