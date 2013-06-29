using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Article
    {
        public long Id { get; set; }
        public long BlogId { get; set; }
        public string MediaUrl { get; set; }
        public Nullable<long> MediaTypeId { get; set; }
        public string Caption { get; set; }
        public System.DateTime CreationDate { get; set; }

        public List<Dbo.Tag> Tags { get; set; }
        public List<Dbo.Comment> Comment { get; set; }
    }
}
