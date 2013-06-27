using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class T_ThemeCRUD
    {
        public static void Create(T_Theme theme)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Theme.Add(theme);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Theme Get(long themeId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Theme.Where(thm => thm.Id == themeId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long themeId, T_Theme thm)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Theme theme = Get(themeId);
                    theme = thm;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long themeId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Theme.Remove(Get(themeId));
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
