using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Tag
    {
        private long _id;
        private string _name;
        private List<Article> _articles;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Article> Articles
        {
            get { return _articles; }
            set { _articles = value; }
        }
        #endregion

        public Tag()
        {
            _id = 0;
            _name = "";
            _articles = new List<Article>();
        }
    }
}
