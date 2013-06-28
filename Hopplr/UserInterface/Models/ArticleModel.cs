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
        public long BlogId {get; set;}

        [Required(ErrorMessage = "Précisez l'url du média")]
        public string mediaUrl { get; set; }
        [Required(ErrorMessage = "Selectionnez un type de média")]
        public long mediaType { get; set; }
        [Required(ErrorMessage = "Le texte est obligatoire")]
        public string text { get; set; }
    }
}