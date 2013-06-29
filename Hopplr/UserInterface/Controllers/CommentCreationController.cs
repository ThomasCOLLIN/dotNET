using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class CommentCreationController : Controller
    {
        [HttpPost]
        public ActionResult AddComment(long blogId, long articleId, String comment)
        {
            // if there is no comment, we do nothing
            if (!String.IsNullOrEmpty(comment))
            {
                long? userId = BusinessManagement.User.GetUserId(User.Identity.Name);
                if (userId == null)
                    throw new Exception("User doesn't exist");

                BusinessManagement.Comment.Create(new Dbo.Comment()
                {
                    UserId = userId.Value,
                    ArticleId = articleId,
                    Content = comment,
                    CreationDate = DateTime.Now
                });
            }

            return RedirectToAction("Display", "ArticleDisplay", new { articleId = articleId });
        }
    }
}
