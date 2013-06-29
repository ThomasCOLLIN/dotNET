using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class SearchTagsModel
    {
        public List<DataAccess.T_Article> articles { get; set; }
        public string tags { get; set; }
    }
}