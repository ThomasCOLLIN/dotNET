using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services
{
    [DataContract]
    public class Article
    {
        private string _text;
        private string _mediaUrl;
        private long _id;
        private DateTime _creationDate;
        private List<string> _tags;

        [DataMember]
        public List<string> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }

        [DataMember]
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        [DataMember]
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public string MediaUrl
        {
            get { return _mediaUrl; }
            set { _mediaUrl = value; }
        }

        [DataMember]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}