using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class BlogListModel
    {
        public List<DataAccess.T_Blog> blogs { get; set; }
        public DataAccess.T_User user { get; set; }
    }
}