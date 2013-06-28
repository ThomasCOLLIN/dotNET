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

            ViewBag.Title = blog.GetName();
            ViewBag.CssPath = Url.Content(blog.GetStylePath());
            ViewBag.Author = blog.GetAuthor();
            ViewBag.Desc = blog.GetDescription();
            ViewBag.Articles = blog.GetArticles();
            return View();
        }

        public string Test()
        {
            return "toto";
        }
    }
}
