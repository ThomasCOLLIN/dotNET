using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class T_ArticleTagCRUD
    {
        public static void Create(T_ArticleTag articleTag)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_ArticleTag.Add(articleTag);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_ArticleTag Get(long articleTagId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_ArticleTag.Where(art => art.Id == articleTagId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long articleTagId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_ArticleTag.Remove(Get(articleTagId));
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
