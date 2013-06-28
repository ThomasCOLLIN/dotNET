using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Search
    {
        public static List<DataAccess.T_Blog> SearchByTheme(string theme)
        {
            return DataAccess.Search.SearchByTheme(theme);
        }

        public static List<DataAccess.T_User> SearchByUser(string user)
        {
            return DataAccess.Search.SearchByUser(user);
        }

        public static List<DataAccess.T_Article> SearchByTags(string tags)
        {
            return DataAccess.Search.SearchByTags(tags);
        }
    }
}
