using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class BlogDisplayModel
    {
        public long IdBlog { get; set; }
        //public long UserId { get; set; }

        public String Title { get; set; }
        public String CssPath { get; set; }
        public String Author { get; set; }
        public String Description { get; set; }
        public List<Models.ArticleModel> ArticleModels { get; set; }

    }
}