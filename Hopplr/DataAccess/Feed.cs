using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Feed
    {
        public static List<Article> GetBlogContent(string userName, string blogName)
        {
            using (HopplrEntities entities = new HopplrEntities())
            {
                try
                {
                    User user = entities.User.Where(usr => usr.Pseudo == userName).FirstOrDefault();
                    Blog blog = entities.Blog.Include("Article").Where(blg => blg.Nom == blogName && blg.UserId == user.id).FirstOrDefault();

                    return new List<Article>(blog.Article);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                    throw;
                }
            }
        }
    }
}
