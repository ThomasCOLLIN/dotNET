using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class T_MediaTypeCRUD
    {
        public static void Create(T_MediaType mediaType)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_MediaType.Add(mediaType);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_MediaType Get(long mediaTypeId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_MediaType.Where(mdType => mdType.Id == mediaTypeId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long mediaTypeId, T_MediaType mdType)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_MediaType mediaType = Get(mediaTypeId);
                    mediaType = mdType;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long mediaTypeId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_MediaType.Remove(Get(mediaTypeId));
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
