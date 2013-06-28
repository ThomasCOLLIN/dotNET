using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class FileModel
    {
        public long BlogId { get; set; }

        [Required(ErrorMessage = "Vous devez sélectionner un fichier.")]
        [Display(Name = "Fichier")]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Légende")]
        public String Caption { get; set; }
    }
}