using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class RssArticle
    {
        private DateTime _creationDate;
        private String _title;
        private String _content;

        #region Getter / Setter
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }
        #endregion

        public RssArticle()
        {
            _content = "";
            _title = "";
            _creationDate = DateTime.Now;
        }
    }
}
