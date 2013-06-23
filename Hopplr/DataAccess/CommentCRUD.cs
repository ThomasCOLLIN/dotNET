using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class T_CommentCRUD
    {
        public static void Create(T_Comment comment)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Comment.Add(comment);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Comment Get(long commentId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Comment.Where(cmmnt => cmmnt.Id == commentId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long commentId, T_Comment cmmnt)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Comment comment = Get(commentId);
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
                using (Entities bdd = new Entities())
                {
                    bdd.T_Comment.Remove(Get(commentId));
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
