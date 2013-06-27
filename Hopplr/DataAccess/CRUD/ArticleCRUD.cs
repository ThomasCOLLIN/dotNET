using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticleCRUD
    {

        public static void Create(T_Article article)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Article.Add(article);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Article Get(long articleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Article.Where(art => art.Id == articleId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Article> GetWithBlog(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Article.Where(art => art.BlogId == blogId).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long articleId, T_Article newT_Article)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Article article = Get(articleId);
                    article = newT_Article;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long articleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Article.Remove(Get(articleId));
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}
