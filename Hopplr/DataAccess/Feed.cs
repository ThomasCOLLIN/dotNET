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
        public static List<T_Article> GetBlogContent(string userName, string blogName)
        {
            using (Entities bdd = new Entities())
            {
                try
                {
                    T_User user = bdd.T_User.Where(usr => usr.Login == userName).FirstOrDefault();
                    T_Blog blog = bdd.T_Blog.Include("Article").Where(blg => blg.Name == blogName && blg.UserId == user.Id).FirstOrDefault();

                    return new List<T_Article>(blog.T_Article);
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
