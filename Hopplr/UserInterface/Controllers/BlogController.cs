using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserInterface.Models;

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

            BlogDisplayModel model = new BlogDisplayModel()
            {
                IdBlog = blog.Id,
                Title = blog.GetName(),
                CssPath = Url.Content(blog.GetStylePath()),
                Author = blog.GetAuthor(),
                Description = blog.GetDescription(),
                ArticleModels = blog.GetArticlesDbo().Select(a => new ArticleModel()
                {
                    ArticleId = a.Id,
                    BlogId = a.BlogId,
                    MediaUrl = a.MediaUrl,
                    MediaType = a.MediaTypeId.Value,
                    Caption = a.Caption,
                    Tags = a.Tags,
                    Comments = a.Comments                    
                }).ToList()
            };
            
            return View(model);
        }

        public ActionResult DisplayUserBlogs(long id)
        {
            Models.BlogListModel model = new Models.BlogListModel()
            {
                blogs = BusinessManagement.Search.SearchBlogFronUser(id),
                user = BusinessManagement.User.GetById(id)
            };

            return View(model);
        }

        #region Follow/UnFollow

        public ActionResult FollowBlog(long id)
        {
            BusinessManagement.Follow.FollowBlog(User.Identity.Name, id);
            return RedirectToAction("Display", new { id = id });
        }

        public ActionResult UnFollow(long id)
        {
            BusinessManagement.Follow.UnFollow(User.Identity.Name, id);
            return RedirectToAction("Display", new { id = id });
        }

        #endregion Follow/UnFollow
    }
}
