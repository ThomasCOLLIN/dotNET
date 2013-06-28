using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public class MediaType
    {
        public T_MediaType getMediaType(long mediaTypeId)
        {
            return T_MediaTypeCRUD.Get(mediaTypeId);
        }
    }
}
