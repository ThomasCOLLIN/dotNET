using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class BlogModel
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Choisissez un style")]
        public long Style { get; set; }
        [Required(ErrorMessage = "Choisissez un theme")]
        public long Theme { get; set; }


    }
}