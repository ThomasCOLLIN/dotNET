using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Search
    {
        public static List<T_Blog> SearchByTheme(string theme)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Include("T_Theme").Where(blg => blg.T_Theme.Description.Equals(theme)).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return new List<T_Blog>();
            }
        }

        public static List<T_User> SearchByUser(string name)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_User.Where((usr) => usr.Login.Equals(name, StringComparison.CurrentCultureIgnoreCase) 
                                                || usr.FirstName.Equals(name, StringComparison.CurrentCultureIgnoreCase)).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return new List<T_User>();
            }
        }

        public static List<T_Article> SearchByTags(string tags)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    List<T_ArticleTag> atList = T_ArticleTagCRUD.GetAll();
                    List<T_Article> resList = new List<T_Article>();
                    List<String> tagList = new List<string>(tags.Split(' '));

                    foreach (T_ArticleTag arta in atList)
                    {
                        foreach (string tag in tagList)
                        {
                            T_Tag curTag = DataAccess.T_TagCRUD.GetByName(tag);
                            if (arta.TagId == curTag.Id)
                            {
                                Boolean present = false;
                                foreach (T_Article elt in resList)
                                {
                                    if (elt.Id == arta.ArticleId)
                                        present = true;
                                }
                                if (!present)
                                    resList.Add(ArticleCRUD.Get(arta.ArticleId));
                            }
                        }
                    }
                    return resList.Distinct().ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return new List<T_Article>();
            }
        }

        public static List<T_Blog> SearchBlogFromUser(long userId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Blog.Include("T_User").Where(blg => blg.T_User.Id == userId).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return new List<T_Blog>();
            }
        }
    }
}
