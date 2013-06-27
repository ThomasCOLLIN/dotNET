using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class User
    {
        /// <summary>
        /// Get the relative path of the CSS file of the Style of the user.
        /// </summary>
        /// <param name="user">login of the user</param>
        /// <returns>Relative path to the file</returns>
        public static string GetCSSPath(string user)
        {
            DataAccess.T_Style style = DataAccess.StyleCRUD.Get(DataAccess.UserCRUD.GetUserByLogin(user).StyleId);
            return style.CSSPath;
        }
    }
}
