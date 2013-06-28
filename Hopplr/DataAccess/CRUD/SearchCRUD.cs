using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class SearchCRUD
    {
        public static List<T_Blog> SearchByTheme(string theme)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    List<T_Theme> thList = ThemeCRUD.GetAll();
                    long curId = 0;
                    foreach (T_Theme thm in thList)
                    {
                        if (string.Compare(thm.Description, theme) == 0)
                            curId = thm.Id;
                    }
                    return bdd.T_Blog.Include("T_Theme").Where(blg => blg.ThemeId == curId).ToList();
                    //return bdd.T_Blog.Include("T_Theme").Where(blg => blg.T_Theme.Description.Equals("theme name")).ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return new List<T_Blog>();
        }

        public static List<T_User> SearchByUser(string name)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    List<T_User> usList = UserCRUD.GetAll();
                    List<T_User> resList = new List<T_User>();
                    foreach (T_User usr in usList)
                    {
                        if (string.Compare(usr.Login, name) == 0)
                            resList.Add(usr);
                        else if (string.Compare(usr.FirstName, name) == 0)
                            resList.Add(usr);
                    }
                    return resList;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return new List<T_User>();
        }

        public static List<T_Article> SearchByTags(string tags)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    //List<T_Tag> usList = T_TagCRUD.GetAll();
                    /*List<T_Article> arList = ArticleCRUD.GetAll();
                    List<T_Article> resList = new List<T_Article>();
                    List<String> tagList = new List<string>(tags.Split(' '));

                    foreach (T_Article art in arList)
                    {
                        if (string.Compare(art.Login, tags) == 0)
                            resList.Add(art);
                        else if (string.Compare(art.FirstName, tags) == 0)
                            resList.Add(art);
                    }
                    return resList;*/
                    return new List<T_Article>();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return new List<T_Article>();
        }
    }
}
