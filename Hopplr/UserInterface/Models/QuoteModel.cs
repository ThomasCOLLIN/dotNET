using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class QuoteModel
    {
        [Required(ErrorMessage = "La citation ne peut pas être vide.")]
        [Display(Name = "Citation")]
        public String Quote { get; set; }

        [Display(Name = "Légende")]
        public String Caption { get; set; }
    }
}