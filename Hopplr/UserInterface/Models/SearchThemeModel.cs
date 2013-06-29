using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class SearchThemeModel
    {
        public List<DataAccess.T_Blog> Blogs { get; set; }
        public string Theme { get; set; }
    }
}