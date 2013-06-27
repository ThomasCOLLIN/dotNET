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
