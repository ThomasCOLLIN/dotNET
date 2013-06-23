using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class MediaTypeCRUD
    {
        public static void Create(MediaType mediaType)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.MediaType.Add(mediaType);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static MediaType Get(long mediaTypeId)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    return bdd.MediaType.Where(mdType => mdType.id == mediaTypeId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long mediaTypeId, MediaType mdType)
        {
            try
            {
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    MediaType mediaType = Get(mediaTypeId);
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
                using (HopplrEntities bdd = new HopplrEntities())
                {
                    bdd.MediaType.Remove(Get(mediaTypeId));
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
