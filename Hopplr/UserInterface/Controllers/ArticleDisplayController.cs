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
        private static readonly string BASE_URL = "http://localhost:5288";

        //
        // GET: /ArticleDisplay/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(long articleId)
        {
            Dbo.Article article = BusinessManagement.Article.GetArticleDbo(articleId);
            Models.ArticleModel model = new Models.ArticleModel()
                {
                    ArticleId = article.Id,
                    BlogId = article.BlogId,
                    Caption = article.Caption,
                    MediaType = article.MediaTypeId.Value,
                    MediaUrl = article.MediaUrl,
                    Tags = article.Tags,
                    Comments = article.Comments
                };

            //ViewData.Model = new ArticleModel();
            string articleUrl = BASE_URL + "/ArticleDisplay/Display?id=" + articleId;
            ViewBag.urlFB = HttpUtility.UrlEncode(articleUrl);
            ViewBag.urlTw = articleUrl;

            return View(model);
        }

        public string Test(string dadaire)
        {
            return dadaire;
        }

    }
}
