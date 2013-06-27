using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class DropDownLists
    {
        public static List<DataAccess.T_Theme> getThemes()
        {
            return DataAccess.ThemeCRUD.GetAll();
        }

        public static List<DataAccess.T_Style> getStyles()
        {
            return DataAccess.StyleCRUD.GetAll();
        }
    }
}
