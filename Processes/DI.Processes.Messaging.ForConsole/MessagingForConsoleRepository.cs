using DI.Common.Enumerations;
using DI.Core.Messaging.Interfaces;
using DI.Process.Messaging.ForEmail;
using System;

namespace DI.Processes.Messaging.ForConsole
{
    public class MessagingForConsoleRepository : IMessageRepository
    {
        public void EmailMessage(IMessage message)
        {
            MessagingForEmailRepository.Send(message.MailMessage);
            Console.WriteLine("Sent e-mail to " + message.MailMessage.To + " with the following text:");
            Console.WriteLine("-----");
            Console.WriteLine(message.MailMessage.Subject);
            Console.WriteLine(message.MailMessage.Body);
            Console.WriteLine("-----");
            if (!String.IsNullOrEmpty(message.Text))
            {
                Console.WriteLine("Notes:");
                Console.WriteLine(message.Text);
            }
            Console.WriteLine("");
        }

        public void WriteMessage(IMessage message)
        {
            try
            {
                Console.WriteLine(
                    "\r\n==========BEGIN MESSAGE==========\r\n"
                    + ((message.Type == null) ? "" : "Type: " + message.Type.ToString() + "\r\n")
                    + ((String.IsNullOrEmpty(message.Title)) ? "" : "Title: " + message.Title + "\r\n")
                    + "Time: " + DateTime.Now.ToString() + "\r\n"
                    + "\r\n" + message.Text
                    + "\r\n==========END MESSAGE==========\r\n\r\n");
                message.ResponseCode = StatusCode.OK;
            }
            catch (Exception ex)
            {
                message.ResponseCode = StatusCode.Error;
                message.ResponseText = ex.ToString();
            }
        }
    }
}
