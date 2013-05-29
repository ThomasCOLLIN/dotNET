using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class User
    {
        private long _id;
        private long _styleId;
        private Style _style;
        private string _pseudo;
        private string _nom;
        private string _prenom;
        private string _email;

        // /!\ ne devrait pas etre utilise selon moi // Thomas
        private string _password;

        private List<Blog> _blogs;
        private List<Comment> _comments;
        private List<Blog> _follows;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public long StyleId
        {
            get { return _styleId; }
            set { _styleId = value; }
        }

        public Style Style
        {
            get { return _style; }
            set { _style = value; }
        }

        public string Pseudo
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        internal List<Blog> Blogs
        {
            get { return _blogs; }
            set { _blogs = value; }
        }

        internal List<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        internal List<Blog> Follows
        {
            get { return _follows; }
            set { _follows = value; }
        }
        #endregion

        public User()
        {
            _id = 0;
            _styleId = 0;
            _style = null;
            _pseudo = "";
            _nom = "";
            _prenom = "";
            _email = "";
            _password = "";
            _blogs = new List<Blog>();
            _comments = new List<Comment>();
            _follows = new List<Blog>();
        }
    }
}
