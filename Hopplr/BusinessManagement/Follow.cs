using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Follow
    {
        public static bool doFollow(string user, long blog)
        {
            return DataAccess.FollowCRUD.DoFollow(user, blog);
        }

        public static void UnFollow(string user, long blog)
        {
            DataAccess.T_Follow fl= DataAccess.FollowCRUD.SearchFollow(user,blog);
            if (fl != null)
            {
                DataAccess.FollowCRUD.Delete(fl.Id);
            }
        }

        public static void FollowBlog(string user, long blog)
        {
            DataAccess.T_Follow ffl = new DataAccess.T_Follow()
            {
                BlogId = blog,
                UserId = DataAccess.UserCRUD.GetUserByLogin(user).Id
            };
            DataAccess.FollowCRUD.Create(ffl);
        }
    }
}
