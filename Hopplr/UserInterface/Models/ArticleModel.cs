using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class ArticleModel
    {
        public long ArticleId { get; set; }
        public long BlogId {get; set;}

        [Required(ErrorMessage = "Précisez l'url du média")]
        public string MediaUrl { get; set; }
        [Required(ErrorMessage = "Selectionnez un type de média")]
        public long MediaType { get; set; }
        [Required(ErrorMessage = "Le texte est obligatoire")]
        public string Caption { get; set; }

        public List<Dbo.Tag> Tags {get; set;}
        public List<Dbo.Comment> Comments { get; set;   }

        [Display(Name = "Tags (séparés par des espaces)")]
        public String TagsList { get; set; }
    }
}