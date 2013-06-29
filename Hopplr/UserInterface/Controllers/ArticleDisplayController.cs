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
            DataAccess.T_Article article = BusinessManagement.Article.Get(id);
            Models.ArticleModel model = new Models.ArticleModel()
                {
                    BlogId = article.BlogId,
                    Caption = article.Text,
                    MediaType = article.MediaTypeId.Value,
                    MediaUrl = article.MediaUrl
                };
            //ViewData.Model = new ArticleModel();

            return View(model);
        }

        public string Test(string dadaire)
        {
            return dadaire;
        }

    }
}
