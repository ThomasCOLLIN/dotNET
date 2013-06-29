using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Models
{
    public class VideoModel
    {
        public long BlogId { get; set; }

        [Required(ErrorMessage = "Veuillez saisir une url.")]
        [RegularExpression(@".+youtube\..+", ErrorMessage = "Vous ne pouvez importer que des vidéos Youtube.")]
        [Display(Name = "Lien de la vidéo (youtube)")]
        public String Url { get; set; }

        [Display(Name = "Légende")]
        public String Caption { get; set; }

        [Display(Name = "Tags (séparés par des espaces)")]
        public String Tags { get; set; }
    }
}
