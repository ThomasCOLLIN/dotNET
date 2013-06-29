using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class QuoteModel
    {
        public long BlogId { get; set; }

        [Required(ErrorMessage = "La citation ne peut pas être vide.")]
        [Display(Name = "Citation")]
        public String Quote { get; set; }

        [Display(Name = "Légende")]
        public String Caption { get; set; }

        [Display(Name = "Tags (séparés par des espaces)")]
        public String Tags { get; set; }
    }
}