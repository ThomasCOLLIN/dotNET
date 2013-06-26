using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserCRUD
    {
        public static void Create(T_User user)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_User.Add(user);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_User Get(long userId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_User.Where(usr => usr.Id == userId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_User> GetUsersByLogin(string login)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    List<T_User> users = bdd.T_User.Where(x => x.Login == login).ToList();
                    return users;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Update(long userId, T_User usr)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_User user = Get(userId);
                    user = usr;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long userId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_User.Remove(Get(userId));
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}
