using System.Collections.Generic;

namespace BusinessManagement
{
    public class User
    {
        private DataAccess.T_User user;

        public bool Exists
        {
            get { return user != null; }
        }


        public User(string login)
        {
            user = DataAccess.UserCRUD.GetUserByLogin(login);
        }

        /// <summary>
        /// Get the relative path of the CSS file of the Style of the user.
        /// </summary>
        /// <returns>Relative path to the file</returns>
        public string GetCSSPath()
        {
            DataAccess.T_Style style = DataAccess.StyleCRUD.Get(user.StyleId);
            return style.CSSPath;
        }

        public long getId()
        {
            return user.Id;
        }

        public static void ModifStyleChoice(string user, long style)
        {
            DataAccess.UserCRUD.UpdateStyle(user, style);
        }

        public List<DataAccess.T_Blog> getListBlogs()
        {
            return DataAccess.BlogCRUD.GetWithUser(user.Id);
        }

        public List<DataAccess.T_Blog> getListFollows()
        {
            List<DataAccess.T_Follow> follows = DataAccess.FollowCRUD.GetByuserId(user.Id);
            List<DataAccess.T_Blog> blogs = new List<DataAccess.T_Blog>();

            foreach (DataAccess.T_Follow follow in follows)
            {
                blogs.Add(DataAccess.BlogCRUD.Get(follow.BlogId));
            }

            return blogs;
        }

        public static DataAccess.T_User GetById(long id)
        {
            return DataAccess.UserCRUD.Get(id);
        }

        public bool IsPasswordValid(string password)
        {
            return (user.HashPassword == password);
        }
    }
}
