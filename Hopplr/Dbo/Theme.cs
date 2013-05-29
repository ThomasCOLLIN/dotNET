using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Theme
    {
        private long _id;
        private string _description;
        private List<Blog> _blogs;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
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
        #endregion

        public Theme()
        {
            _id = 0;
            _description = "";
            _blogs = new List<Blog>();
        }
    }
}
