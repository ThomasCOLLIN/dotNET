using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class BlogCRUD
    {
        public static void Create(Blog blog)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Blog.Add(blog);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Blog Get(long blogId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.Blog.Where(bl => bl.id == blogId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Blog Get(long blogId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.Blog.Include(Article).Where(bl => bl.id == blogId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long blogId, Blog blg)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    Blog blog = Get(blogId);
                    blog = blg;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void AddArticle(long blogId, Article article)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    Blog blog = GetWithArticles(blogId);
                    blog.Article.Add(article);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long blogId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Blog.Remove(Get(blogId));
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
