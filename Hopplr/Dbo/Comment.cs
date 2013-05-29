using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Comment
    {
        private long _id;
        private long _userId;
        private long _articleId;
        private string _comment;
        private DateTime _date;
        private Article _article;
        private User _user;

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

        public long ArticleId
        {
            get { return _articleId; }
            set { _articleId = value; }
        }

        public string Comment1
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Article Article
        {
            get { return _article; }
            set { _article = value; }
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }
        #endregion

        public Comment()
        {
            _id = 0;
            _userId = 0;
            _articleId = 0;
            _comment = "";
            _date = DateTime.MinValue;
            _article = null;
            _user = null;
        }
    }
}
