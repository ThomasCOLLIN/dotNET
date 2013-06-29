using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FollowCRUD
    {
        public static void Create(T_Follow follow)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Follow.Add(follow);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Follow Get(long followId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Follow.Where(fllw => fllw.Id == followId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Follow> GetByuserId(long UserId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Follow.Where(fllw => fllw.UserId == UserId).ToList(); ;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static bool DoFollow(string user, long blog)
        {
            try
            {
                List<T_Follow> fl;
                using (Entities bdd = new Entities())
                {
                    T_User us = bdd.T_User.Where(u => u.Login == user).ToList().FirstOrDefault();
                    fl = bdd.T_Follow.Where(ffl => ffl.UserId == us.Id).ToList();

                }
                foreach (T_Follow follow in fl)
                {
                    if (follow.BlogId == blog)
                        return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Follow SearchFollow(string user, long blog)
        {
            try
            {
                List<T_Follow> fl;
                using (Entities bdd = new Entities())
                {
                    T_User us = bdd.T_User.Where(u => u.Login == user).ToList().FirstOrDefault();
                    fl = bdd.T_Follow.Where(ffl => ffl.UserId == us.Id).ToList();

                }
                foreach (T_Follow follow in fl)
                {
                    if (follow.BlogId == blog)
                        return follow;
                }
                return null;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long followId, T_Follow fllw)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Follow follow = Get(followId);
                    follow = fllw;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long id)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Follow.Remove(bdd.T_Follow.Where(x => x.Id == id).FirstOrDefault());
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
