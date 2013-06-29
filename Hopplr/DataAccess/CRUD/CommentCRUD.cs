using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommentCRUD
    {
        public static void Create(Dbo.Comment comment)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Comment.Add(new T_Comment()
                        {
                            UserId = comment.UserId,
                            ArticleId = comment.ArticleId,
                            Comment = comment.Content,
                            CreationDate = comment.CreationDate
                        });
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static Dbo.Comment Get(long commentId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Comment
                                .Where(cmmnt => cmmnt.Id == commentId)
                                .Select(c => new Dbo.Comment()
                                {
                                    Id = c.Id,
                                    UserId = c.UserId,
                                    ArticleId = c.ArticleId,
                                    Content = c.Comment,
                                    CreationDate = c.CreationDate
                                })
                                .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        //public static void Update(long commentId, Dbo.Comment cmmnt)
        //{
        //    try
        //    {
        //        using (Entities bdd = new Entities())
        //        {
        //            T_Comment comment = Get(commentId);
        //            comment = cmmnt;
        //            bdd.SaveChanges();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Trace.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        public static void Delete(long commentId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Comment comment = bdd.T_Comment.Where(c => c.Id == commentId).FirstOrDefault();
                    if (comment == null)
                        return;
                    bdd.T_Comment.Remove(comment);
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
