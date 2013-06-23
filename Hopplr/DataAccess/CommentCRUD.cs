using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class CommentCRUD
    {
        public static void Create(Comment comment)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Comment.Add(comment);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Comment Get(long commentId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.Comment.Where(cmmnt => cmmnt.id == commentId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long commentId, Comment cmmnt)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    Comment comment = Get(commentId);
                    comment = cmmnt;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long commentId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.Comment.Remove(Get(commentId));
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
