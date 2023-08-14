﻿using System.ComponentModel.DataAnnotations;

namespace MotivWebApp.Models
{
    public class QuoteInput
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
        [Range(1, 1000000)]
        [DataType(DataType.Currency)]
        public float Income { get; set; } = 1;
        [Required]
        public bool ImpulseBuys { get; set; } = false;
        [Required]
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public float SillyHatSpend { get; set; } = 1;
    }
}
