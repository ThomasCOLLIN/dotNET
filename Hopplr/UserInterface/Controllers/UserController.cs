using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Profile of the user
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// List the blogs of the user
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Blog()
        {
            BusinessManagement.User user = new BusinessManagement.User(User.Identity.Name);
            ViewBag.ListBlog = user.getListBlogs();
            return View();
        }

        /// <summary>
        /// List the blogs followed by the user
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Follows()
        {
            BusinessManagement.User user = new BusinessManagement.User(User.Identity.Name);
            ViewBag.ListBlog = user.getListFollows();
            return View();
        }

        /// <summary>
        /// List the followers (user that follow at least 1 blog of the User)
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Followers()
        {
            return View();
        }

        public ActionResult BlogManagement(long id)
        {
            BusinessManagement.Blog blog = new BusinessManagement.Blog(id);

            ViewBag.Title = blog.getName();
            ViewBag.Author = blog.getAuthor();
            ViewBag.Desc = blog.getDescription();
            ViewBag.Articles = blog.getArticles();

            return View();
        }
    }
}
