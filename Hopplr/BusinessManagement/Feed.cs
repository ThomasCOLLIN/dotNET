using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Feed
    {
        public static List<DataAccess.Article> GetBlogContent(string user, string blog)
        {
            return DataAccess.Feed.GetBlogContent(user, blog);
        }
    }
}
