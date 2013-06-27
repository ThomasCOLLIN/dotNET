using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StyleCRUD
    {
        public static void Create(T_Style style)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Style.Add(style);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Style Get(long styleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Style.Where(stl => stl.Id == styleId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long styleId, T_Style stl)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Style style = Get(styleId);
                    style = stl;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long styleId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Style.Remove(Get(styleId));
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
