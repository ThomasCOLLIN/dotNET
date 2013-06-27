using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class Registration
    {
        public static void RegisterAccount(Dbo.Account account)
        {
            if (!IsAccountValid(account))
                return;

            DataAccess.T_User user = new DataAccess.T_User();
            user.Email = account.Email.Trim();
            user.Login = account.Login.Trim();
            user.HashPassword = account.Password.Trim();
            user.FirstName = account.Firstname.Trim();
            user.LastName = account.Lastname.Trim();
            user.T_Style = DataAccess.StyleCRUD.GetDefault();
            user.StyleId = user.T_Style.Id;
            
            DataAccess.UserCRUD.Create(user);

            // pas utile en local ^^'
            // SendValidationEmail(user.Email);
        }

        public static bool IsAccountValid(Dbo.Account account)
        {
            return IsLoginValid(account.Login)
                && IsPasswordValid(account.Password)
                && IsEmailValid(account.Email)
                && IsFirstnameValid(account.Firstname)
                && IsLastnameValid(account.Lastname);
        }

        public static bool IsLoginValid(string login)
        {
            Regex regex = new Regex("^[-_ a-zA-Z0-9]*$");

            return login.Trim() != "" && regex.IsMatch(login.Trim()) && !DataAccess.UserCRUD.DoesLoginExists(login.Trim());
        }

        public static bool IsPasswordValid(string password)
        {
            return password.Trim() != "";
        }

        public static bool IsEmailValid(string email)
        {
            return email.Trim() != "" && !DataAccess.UserCRUD.DoesEmailExists(email.Trim());
        }

        public static bool IsFirstnameValid(string firstname)
        {
            Regex regex = new Regex("^[-_ a-zA-Z0-9]*$");
            return firstname.Trim() != "" && regex.IsMatch(firstname.Trim());
        }

        public static bool IsLastnameValid(string lastname)
        {
            Regex regex = new Regex("^[-_ a-zA-Z0-9]*$");
            return lastname.Trim() != "" && regex.IsMatch(lastname.Trim());
        }

        private static void SendValidationEmail(string email)
        {
            Utils.Email.Send(email, "Hopplr registration", "Your registration is now complete. See you soon on Hopplr");
        }
    }
}
