using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbo
{
    public class Account
    {
        private string _login;
        private string _password;
        private string _email;
        private string _firstname;
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public Account()
        {
            _login = "";
            _password = "";
            _email = "";
            _firstname = "";
            _lastname = "";
        }
    }
}
