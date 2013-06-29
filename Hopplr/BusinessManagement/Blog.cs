using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Blog
    {
        private DataAccess.T_Blog blog;

        public bool Exists
        {
            get { return blog != null; }
        }

        public Blog(long id)
        {
            blog = DataAccess.BlogCRUD.Get(id);
        }

        public Blog(string username, string blogname)
        {
            blog = DataAccess.BlogCRUD.Get(username, blogname);
        }

        public Blog()
        {
            blog = null;
        }

        public T_Blog GetBlog(long id)
        {
            return BlogCRUD.Get(id);
        }

        public static List<DataAccess.T_Blog> getList()
        {
            return DataAccess.BlogCRUD.GetList();
        }

        public static void CreateBlog(string user, long styleId, long themeId, string name, string desc)
        {
            long uid = DataAccess.UserCRUD.GetUserByLogin(user).Id;
            DataAccess.T_Blog blog = new DataAccess.T_Blog()
            {
                UserId = uid,
                CreationDate = DateTime.Now,
                Description = desc,
                Name = name,
                StyleId = styleId,
                ThemeId = themeId
            };
            DataAccess.BlogCRUD.Create(blog);
        }

        public static void CreateArticle(long blogid, string mediaurl, long type, string text)
        {
            DataAccess.T_Article art = new DataAccess.T_Article()
            {
                CreationDate = DateTime.Now,
                BlogId = blogid,
                MediaTypeId = type,
                MediaUrl = mediaurl,
                Text = text
            };
            DataAccess.ArticleCRUD.Create(art);
        }

        public string GetName()
        {
            if (blog == null)
                return null;
            return blog.Name;
        }

        public string GetDescription()
        {
            if (blog == null)
                return null;
            return blog.Description;
        }

        public string GetStylePath()
        {
            if (blog == null)
                return null;
            return DataAccess.StyleCRUD.Get(blog.StyleId).CSSPath;
        }

        public List<DataAccess.T_Article> GetArticles()
        {
            if (blog == null)
                return null;
            return DataAccess.ArticleCRUD.GetWithBlog(blog.Id);
        }

        public string GetAuthor()
        {
            if (blog == null)
                return null;
            T_User user = DataAccess.UserCRUD.Get(blog.UserId);
            
            return user != null ? user.Login : null;
        }

        public T_User GetAuthor(long blogId)
        {
            return DataAccess.BlogCRUD.GetUserWithBlogId(blogId);
        }
    }
}
