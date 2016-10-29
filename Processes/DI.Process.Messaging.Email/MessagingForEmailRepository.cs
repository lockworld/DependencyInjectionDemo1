using DI.Infrastructure.Messaging.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DI.Process.Messaging.ForEmail
{
    public class MessagingForEmailRepository
    {
        private static int _daysToExpiration = 30;
        public static void Send(MailMessage message)
        {
            // Queue an e-mail to send later
            using (EmailDbContext db = new EmailDbContext())
            {
                try
                {
                    EmailMessage emailMessage = new EmailMessage
                    {
                        Id = Guid.NewGuid(),
                        From = ((message.From==null) ? (new MailAddress("doug@lockwood-family.com", "Doug Lockwood's Application")).ToString() : message.From.ToString()),
                        To = message.To.ToString(),
                        Cc = message.CC.ToString(),
                        Bcc = message.Bcc.ToString(),
                        Subject = message.Subject,
                        Body = message.Body,
                        IsBodyHtml = message.IsBodyHtml,
                        ReplyTo = message.ReplyToList.ToString(),
                        Created = DateTime.Now,
                        Expires = DateTime.Now.AddDays(_daysToExpiration)
                    };

                    db.Email.Add(emailMessage);
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
                
            }
            ////// Send an e-mail            
            ////SmtpClient client = new SmtpClient
            ////{
            ////    Host = "host276.hostmonster.com",
            ////    Credentials = new NetworkCredential("doug@lockwood-family.com", "D0ugl@$L"),
            ////};

            ////message.From = new MailAddress("doug@lockwood-family.com");

            ////if (message.IsBodyHtml)
            ////{
            ////    message.Body = message.Body.Replace(@"\r\n", "<br/>");
            ////}

            ////message.Body +=
            ////    ((message.IsBodyHtml) ? "<p>&nbsp;</p><hr/><footer><p>" : "\r\n\r\n--------------------\r\n")
            ////    + "This message was sent by McREL International through an unmonitored e-mail address. Please do not reply to this e-mail."
            ////    + ((message.IsBodyHtml) ? "</p><p>" : "\r\n\r\n")
            ////    + "You can learn more about McREL International by visiting us "
            ////    + ((message.IsBodyHtml) ? "<a href=\"http://www.mcrel.org\">online</a>.</p><p>" : "online at http://www.mcrel.org.\r\n\r\n")
            ////    + "McREL International"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + "4601 DTC Boulevard, Suite 500"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + "Denver, CO 80237-2596"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + "P: 303.337.0990"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + "F: 303.337.3005"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + "info@mcrel.org"
            ////    + ((message.IsBodyHtml) ? "<br/>" : "\r\n")
            ////    + ((message.IsBodyHtml) ? "<a href=\"http://www.mcrel.org\">www.mcrel.org</a>" : "http://www.mcrel.org")
            ////    + ((message.IsBodyHtml) ? "</p></footer>" : "\r\n--------------------\r\n")
            ////    ;
            

            ////client.Send(message);
        }
    }
}
