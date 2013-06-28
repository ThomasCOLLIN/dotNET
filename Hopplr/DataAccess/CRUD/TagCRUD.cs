using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class T_TagCRUD
    {
        public static void Create(T_Tag tag)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Tag.Add(tag);
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Tag Get(long tagId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Tag.Where(tg => tg.Id == tagId).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Update(long tagId, T_Tag tg)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    T_Tag tag = Get(tagId);
                    tag = tg;
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static void Delete(long tagId)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    bdd.T_Tag.Remove(Get(tagId));
                    bdd.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static List<T_Tag> GetAll()
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Tag.ToList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        public static T_Tag GetByName(string name)
        {
            try
            {
                using (Entities bdd = new Entities())
                {
                    return bdd.T_Tag.Where(tg => tg.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
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
