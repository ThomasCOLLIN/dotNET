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
        public ActionResult Profile()
        {
            BusinessManagement.User user = new BusinessManagement.User(User.Identity.Name);

            ViewBag.Username = User.Identity.Name;
            ViewBag.Name = user.getName();
            ViewBag.FirstName = user.getFirstName();

            ViewBag.NumBlog = user.getNumBlog();

            return View();
        }

        [HttpPost]
        public ActionResult Profile(StyleChoiceModel model)
        {
            BusinessManagement.User.ModifStyleChoice(User.Identity.Name, model.style);

            return RedirectToAction("Profile", "User");
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
        public ActionResult Followers(long id)
        {
            List<DataAccess.T_Blog> blgList = BusinessManagement.Blog.GetWithUser(id);
            List<Tuple<DataAccess.T_Blog, List<DataAccess.T_User>>> resList = new List<Tuple<DataAccess.T_Blog, List<DataAccess.T_User>>>();

            foreach (DataAccess.T_Blog blg in blgList)
            {
                resList.Add(new Tuple<DataAccess.T_Blog, List<DataAccess.T_User>>(blg, BusinessManagement.Blog.GetFollower(blg.Id)));
            }
            Models.FollowersModel model = new Models.FollowersModel()
            {
                blogList = resList,
                name = BusinessManagement.User.GetById(id).Login
            };

            return View(model);
        }

        public ActionResult BlogManagement(long id)
        {
            BusinessManagement.Blog blog = new BusinessManagement.Blog(id);
            
            if (User.Identity.Name != blog.GetAuthor())
                RedirectToAction("Blog");

            ViewBag.Title = blog.GetName();
            ViewBag.Articles = blog.GetArticles();
            ViewBag.id = id;


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
