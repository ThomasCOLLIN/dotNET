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
            return View();
        }

        /// <summary>
        /// List the blogs followed by the user
        /// </summary>
        /// <returns>The view</returns>
        public ActionResult Follows()
        {

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
    }
}
