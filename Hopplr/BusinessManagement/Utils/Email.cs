using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BusinessManagement.Utils
{
    public class Email
    {
        private static readonly string emailServer = "thmcollin@gmail.com";

        public static void Send(string to, string title, string content)
        {
            try
            {
                MailMessage message = new MailMessage(emailServer, to, title, content);
                SmtpClient client = new SmtpClient("localhost", 8008);
                client.Send(message);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}
