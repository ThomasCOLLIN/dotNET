﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Comment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long ArticleId { get; set; }
        public string Content { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}
