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

        public Blog(long id)
        {
            blog = DataAccess.BlogCRUD.Get(id);
        }

        public string getName()
        {
            return blog.Name;
        }

        public string getDescription()
        {
            return blog.Description;
        }

        public string getStylePath()
        {
            return DataAccess.StyleCRUD.Get(blog.StyleId).CSSPath;
        }

        public List<DataAccess.T_Article> getArticles()
        {
            return DataAccess.ArticleCRUD.GetWithBlog(blog.Id);
        }

        public string getAuthor()
        {
            return DataAccess.UserCRUD.Get(blog.UserId).Login;
        }
    }
}
