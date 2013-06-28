using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Article
    {
        public void Create(T_Article article)
        {
            ArticleCRUD.Create(article);
        }

        public T_Article Get(long articleId)
        {
            return ArticleCRUD.Get(articleId);
        }

        public List<T_Article> GetWithBlog(long blogId)
        {
            return ArticleCRUD.GetWithBlog(blogId);
        }

        public void Update(long articleId, T_Article newT_Article)
        {
            ArticleCRUD.Update(articleId, newT_Article);
        }

        public void Delete(long articleId)
        {
            ArticleCRUD.Delete(articleId);
        }
    }
}
