using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Style
    {
        private long _id;
        private string _cssPath;
        private string _description;

        // /!\ ne devrait pas etre utilise selon moi // Thomas
        private List<Blog> _blogs;
        private List<User> _users;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CssPath
        {
            get { return _cssPath; }
            set { _cssPath = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<Blog> Blogs
        {
            get { return _blogs; }
            set { _blogs = value; }
        }

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        #endregion

        public Style()
        {
            _id = 0;
            _cssPath = "";
            _description = "";
            _blogs = new List<Blog>();
            _users = new List<User>();
        }
    }
}
