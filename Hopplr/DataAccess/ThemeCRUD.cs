using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ThemeCRUD
    {
        public static void Create(Theme theme)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Theme.Add(theme);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Theme Get(long themeId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.Theme.Where(thm => thm.id == themeId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long themeId, Theme thm)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    Theme theme = Get(themeId);
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
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Theme.Remove(Get(themeId));
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
