using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// Get the blog list
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Index()
        {
            ViewBag.ListBlog = BusinessManagement.Blog.getList();
            return View();
        }

        /// <summary>
        /// Return the articles of the blog
        /// </summary>
        /// <param name="id">if of the blog</param>
        /// <returns>the view</returns>
        public ActionResult Display(long id)
        {
            BusinessManagement.Blog blog = new BusinessManagement.Blog(id);

            ViewBag.Title = blog.getName();
            ViewBag.CssPath = Url.Content(blog.getStylePath());
            ViewBag.Author = blog.getAuthor();
            ViewBag.Desc = blog.getDescription();
            ViewBag.Articles = blog.getArticles();
            return View();
        }

        public string Test()
        {
            return "toto";
        }
    }
}
