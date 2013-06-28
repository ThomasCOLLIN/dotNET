using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BusinessManagement
{
    public class CustomMemberShip : MembershipProvider
    {
        public override string ApplicationName
        {
            get { return "Hopplr"; }
            set { ;}
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByLogin(username);
            if (user.HashPassword != oldPassword)
                return false;

            user.HashPassword = newPassword;
            return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        //TODO je pense pas devoir retourner null mais je ne sais pas quoi retourner
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            if (!Registration.IsLoginValid(username))
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }

            if (!Registration.IsPasswordValid(password))
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (!Registration.IsEmailValid(email))
            {
                status = MembershipCreateStatus.InvalidEmail;
                return null;
            }

            Dbo.Account account = new Dbo.Account();
            account.Login = username;
            account.Password = password;
            account.Email = email;

            if (Registration.RegisterAccount(account))
            {
                status = MembershipCreateStatus.Success;
                return null;
            }
            else
            {
                status = MembershipCreateStatus.UserRejected;
                return null;
            }
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByLogin(username);
            if (user == null)
                return false;

            DataAccess.UserCRUD.Delete(user.Id);
            return true;
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return true; }
        }

        // TODO same here
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection collection = new MembershipUserCollection();
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByEmail(emailToMatch);
            if (user == null)
                totalRecords = 0;
            else
            {
                collection.Add(null);
                totalRecords = 1;
            }
            return collection;
        }

        // TODO same here
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection collection = new MembershipUserCollection();
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByLogin(usernameToMatch);
            if (user == null)
                totalRecords = 0;
            else
            {
                collection.Add(null);
                totalRecords = 1;
            }
            return collection;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        //TODO same here
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByLogin(username);
            return null;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        //TODO same here
        public override string GetUserNameByEmail(string email)
        {
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByEmail(email);
            return null;
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 30; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 8; }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            return true;
        }

        public override void UpdateUser(MembershipUser user)
        {
            // TODO if you know what to do;
        }

        public override bool ValidateUser(string username, string password)
        {
            DataAccess.T_User user = DataAccess.UserCRUD.GetUserByLogin(username);

            if (user == null)
                return false;

            if (user.HashPassword.Equals(password))
                return true;

            return false;
        }
    }
}
