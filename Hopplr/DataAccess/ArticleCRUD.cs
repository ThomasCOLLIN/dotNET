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
        public static void Create(Article article)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Article.Add(article);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Article Get(long articleId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.Article.Where(art => art.id == articleId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void UpdateText(long articleId, string text)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    Article article = Get(articleId);
                    article.Text = text;
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
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Article.Remove(Get(articleId));
                    bdd.SaveChanges()
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
