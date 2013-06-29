using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UserInterface.Models
{
    public class SearchUserModel
    {
        public List<DataAccess.T_User> user { get; set; }
        public string name { get; set; }
    }
}