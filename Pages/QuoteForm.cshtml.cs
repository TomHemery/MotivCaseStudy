using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace MotivWebApp.Pages
{
    public class QuoteFormModel : PageModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Topping { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000)]
        [DataType(DataType.Currency)]
        public float Income { get; set; } = 0;
        [Required]
        public bool ImpulseBuys { get; set; } = false;
        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public float SillyHatSpend { get; set; } = 0;
    }
}