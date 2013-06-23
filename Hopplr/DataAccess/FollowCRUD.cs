using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class FollowCRUD
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

        public static void Delete(long followId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Follow.Remove(Get(followId));
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
