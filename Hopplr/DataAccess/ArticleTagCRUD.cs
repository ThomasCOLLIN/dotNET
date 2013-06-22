using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticleTagCRUD
    {
        public static void Create(ArticleTag articleTag)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.ArticleTag.Add(articleTag);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static ArticleTag Get(long articleTagId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.ArticleTag.Where(art => art.id == articleTagId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void UpdateTag(long articleTagId, string tag)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    ArticleTag ArticleTag = Get(articleTagId);
                    ArticleTag.Tag = tag;
                    bdd.SaveChanges();
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
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.ArticleTag.Remove(Get(articleTagId));
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
