using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement
{
    public static class Tools
    {
        public enum MediaTypes { Image = 1, Video, Music, Quote };

        /// <summary>
        /// Remove a file from the server.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>True if the file has been deleted, false otherwise.</returns>
        public static Boolean DeleteFile(String path)
        {
            try
            {
                System.IO.File.Delete(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
