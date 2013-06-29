using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class ArticleDisplayController : Controller
    {
        //
        // GET: /ArticleDisplay/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(long id)
        {
            Dbo.Article article = BusinessManagement.Article.GetArticleDbo(id);
            Models.ArticleModel model = new Models.ArticleModel()
                {
                    BlogId = article.BlogId,
                    Caption = article.Caption,
                    MediaType = article.MediaTypeId.Value,
                    MediaUrl = article.MediaUrl,
                    Tags = article.Tags,
                    Comments = article.Comments
                };

            return View(model);
        }

        public string Test(string dadaire)
        {
            return dadaire;
        }

    }
}
