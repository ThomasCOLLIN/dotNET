using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Blog
    {
        private long _id;
        private long _userId;
        private long _styleId;
        private long _themeId;
        private string _nom;
        private string _description;
        private List<Article> _articles;
        private Style _style;
        private Theme _theme;
        private User _user;
        private List<User> _followers;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public long UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public long StyleId
        {
            get { return _styleId; }
            set { _styleId = value; }
        }

        public long ThemeId
        {
            get { return _themeId; }
            set { _themeId = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }

        public Style Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public Theme Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public List<User> Followers
        {
            get { return _followers; }
            set { _followers = value; }
        }
        #endregion

        public Blog()
        {
            _id = 0;
            _userId = 0;
            _styleId = 0;
            _themeId = 0;
            _nom = "";
            _description = "";
            _articles = new List<Article>();
            _style = null;
            _theme = null;
            _user = null;
            _followers = new List<User>();


        }
    }
}
