using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Comment
    {
        public static void Create(Dbo.Comment comment)
        {
            DataAccess.CommentCRUD.Create(comment);
        }

        public static Dbo.Comment Get(long commentId)
        {
            return DataAccess.CommentCRUD.Get(commentId);
        }

        public static void Delete(long commentId)
        {
            DataAccess.CommentCRUD.Delete(commentId);
        }
    }
}
