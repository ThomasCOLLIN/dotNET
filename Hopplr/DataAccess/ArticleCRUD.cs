using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArticleCRUD
    {
        public static void Create(Article article)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Get(long articleId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(Article article)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long articleId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {

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
