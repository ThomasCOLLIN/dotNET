using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchTheme(string theme)
        {
            Models.SearchThemeModel model = new Models.SearchThemeModel()
            {
                Blogs = BusinessManagement.Search.SearchByTheme(theme),
                Theme = theme
            };

            return View(model);
        }

        public ActionResult SearchUser(string userName)
        {
            Models.SearchUserModel model = new Models.SearchUserModel()
            {
                user = BusinessManagement.Search.SearchByUser(userName),
                name = userName
            };

            return View(model);
        }

        public ActionResult SearchTags(string tags)
        {
            Models.SearchTagsModel model = new Models.SearchTagsModel()
            {
                articles = BusinessManagement.Search.SearchByTags(tags),
                tags = tags 
            };

            return View(model);
        }

    }
}
