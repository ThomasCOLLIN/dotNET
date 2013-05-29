using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Article
    {
        public enum MediaType
        {
            None = 0,
            Image = 1,
            Video = 2,
            Son = 3
        }

        private long _id;
        private long _blogId;
        private string _mediaUrl;
        private MediaType _mediaType;
        private string _text;
        private Blog _blog;
        private List<Tag> _tags;
        private List<Comment> _comments;

        #region accesseurs
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public long BlogId
        {
            get { return _blogId; }
            set { _blogId = value; }
        }

        public string MediaUrl
        {
            get { return _mediaUrl; }
            set { _mediaUrl = value; }
        }

        public MediaType MediaType1
        {
            get { return _mediaType; }
            set { _mediaType = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Blog Blog
        {
            get { return _blog; }
            set { _blog = value; }
        }

        public List<Tag> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        public List<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        #endregion

        public Article()
        {
            _id = 0;
            _blogId = 0;
            _mediaUrl = "";
            _mediaType = MediaType.None;
            _text = "";
            _blog = null;
            _tags = new List<Tag>();
            _comments = new List<Comment>();
        }

    }
}
