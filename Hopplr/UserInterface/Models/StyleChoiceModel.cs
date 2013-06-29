using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class StyleChoiceModel
    {
        [Required(ErrorMessage = "Sélectionnez un style")]
        [Display(Name = "Choisissez  un nouveau Theme ")]
        public long style { get; set; }
    }
}