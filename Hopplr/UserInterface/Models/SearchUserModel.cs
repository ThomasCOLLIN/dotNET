﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserInterface.Models
{
    public class SearchUserModel
    {
        public List<DataAccess.T_User> User { get; set; }
        public string name { get; set; }
    }
}