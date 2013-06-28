using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    class SearchCRUD
    {
        public static List<T_Blog> searchByTheme(string theme)
        {
            /*
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Where(blg => blg.th == articleId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
            */
            return null;
        }
    }
}
