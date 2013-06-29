using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class InscriptionModel
    {
        [Required(ErrorMessage = "Indiquez votre nom")]
        [Display(Name = "Nom")]
        public string name { get; set; }
        [Required(ErrorMessage = "Indiquez votre prénom")]
        [Display(Name = "Prénom")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "Indiquez un pseudonyme")]
        [Display(Name = "Pseudo")]
        public string username { get; set; }
        [Required(ErrorMessage = "Indiquez votre adresse email")]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Required(ErrorMessage = "Indiquez un mot de passe")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string mdp { get; set; }
        [Display(Name = "Répétez votre mot de passe")]
        [Required(ErrorMessage = "Répétez votre mot de passe")]
        [DataType(DataType.Password)]
        public string mdpbis { get; set; }
    }
}