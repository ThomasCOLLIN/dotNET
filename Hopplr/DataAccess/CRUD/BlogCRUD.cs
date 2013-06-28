using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BlogCRUD
    {
        public static void Create(T_Blog blog)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Blog.Add(blog);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Blog Get(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Where(bl => bl.Id == blogId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_User GetUserWithBlogId(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_User
                            .Where(u => bdd.T_Blog
                                  .Any(bl => bl.Id == blogId && u.Id == bl.UserId))
                            .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Blog GetWithArticles(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Include("Article").Where(bl => bl.Id == blogId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Blog> GetWithUser(long UserId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Where(bl => bl.UserId == UserId).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Blog> GetList()
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long blogId, T_Blog blg)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Blog blog = Get(blogId);
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

        public static void Delete(long blogId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Blog.Remove(Get(blogId));
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
