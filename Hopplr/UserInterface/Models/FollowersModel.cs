using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class FollowersModel
    {
        public List<Tuple<DataAccess.T_Blog, List<DataAccess.T_User>>> blogList { get; set; }
        public string name { get; set; }
    }
}