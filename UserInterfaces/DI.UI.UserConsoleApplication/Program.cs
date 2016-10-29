using DI.Common.Enumerations;
using DI.Core.Messaging.Interfaces;
using DI.Processes.Messaging.ForConsole.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DI.UI.UserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var messageService = kernel.Get<IMessageService>();
            
            Console.Clear();
            Console.WriteLine(
                  "******************************\r\n"
                + "     BUG REPORT\r\n"
                + "******************************\r\n\r\n");

            Console.WriteLine("Do you want us to e-mail you this bug report?");
            Console.Write("[Y]es/[N]o: ");
            var input = Console.ReadKey();
            bool email = ((input.Key==ConsoleKey.Y) ? true : false);

            Console.WriteLine();

            var message = new Message();
            try
            {
                Console.Write("What is your name? ");
                var name = Console.ReadLine();
                message.Text += "Issue reported by: " + name + "\r\n";

                Console.WriteLine("Please describe the problem:");
                var bug = Console.ReadLine();
                message.Text += "Problem:\r\n-----\r\n" + bug + "\r\n-----\r\n";

                Console.Write("How old are you? ");
                var age = Convert.ToInt32(Console.ReadLine());

                message.Type = StatusCode.OK;
                message.Title = "User Survey Response";
                message.Text += name + " is " + age.ToString() + " years old.";

                messageService.WriteMessage(message);

                if (email)
                {
                    if (age < 18)
                    {
                        string tooyoung = "You are not old enough to receive e-mail.";
                        message.Text += "\r\n " + tooyoung;
                        message.ResponseText += "\r\n" + tooyoung + "\r\n";
                        message.ResponseCode = StatusCode.NotImplemented;
                    }
                    else
                    {
                        message.ResponseCode = StatusCode.Null;
                        message.ResponseText = null;
                        var mail = new MailMessage();
                        mail.To.Add("lockwooddp@msn.com");
                        mail.Subject = message.Title;
                        mail.Body = message.Text;
                        mail.IsBodyHtml = false;
                        message.MailMessage = mail;

                        messageService.EmailMessage(message);
                        Console.WriteLine("\r\n==========\r\nEmail Message Response:\r\n"
                            + message.ResponseCode
                            + "\r\n" + message.ResponseText + "\r\n==========\r\n\r\n");
                    }

                }

            }
            catch (Exception ex)
            {
                message.ResponseCode = StatusCode.Error;
                message.ResponseText = "There was a problem with your survey response.\r\n"
                    + ex.ToString();
            }


            Console.WriteLine("Message Response: " + message.ResponseCode + "\r\n" + message.ResponseText);

            

            
            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
