using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

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
            
            if (User.Identity.Name != blog.getAuthor())
                RedirectToAction("Blog");

            ViewBag.Title = blog.getName();
            ViewBag.Author = blog.getAuthor();
            ViewBag.Desc = blog.getDescription();
            ViewBag.Articles = blog.getArticles();

            return View();
        }


        #region Création de blog

        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(BlogModel bl)
        {
            if (ModelState.IsValid)
            {
                BusinessManagement.Blog.CreateBlog(User.Identity.Name, bl.Style, bl.Theme, bl.Name, bl.Description);

                return RedirectToAction("Blog");
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        #endregion

    }
}
