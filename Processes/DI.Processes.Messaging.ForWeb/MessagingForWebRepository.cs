﻿using DI.Core.Messaging.Interfaces;
using DI.Process.Messaging.ForEmail;
using DI.Processes.Messaging.ForWeb.Entities;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DI.Common.Enumerations;

namespace DI.Processes.Messaging.ForWeb
{
    public class MessagingForWebRepository : IMessageRepository
    {
        public void EmailMessage(IMessage message)
        {
            MessagingForEmailRepository.Send(message.MailMessage);
            var feedback = new Message
            {
                Type = message.ResponseCode,
                Text = ((Status.StatusGroup(message.ResponseCode)==StatusCode.OK)
                        ?
                            "Sent e-mail to " + message.MailMessage.To + " with the following text:"
                            + "<hr/>"
                            + "<p>" + message.MailMessage.Subject + "</p>"
                            + "<p>&nbsp;</p><article>"
                            + message.MailMessage.Body
                            + "</article><hr/>"
                        :
                            "Unable to send e-mail to " + message.MailMessage.To + "."
                            + "<hr/>ERROR: " + message.ResponseCode.ToString()
                            + "<article>" + message.ResponseText + "</article>"
                        )
            };
            WriteMessage(feedback);
        }

        public void WriteMessage(IMessage message)
        {
            try
            {
                var items = HttpContext.Current.Items;
                var messages = (List<IMessage>)items["Messages"];
                if (messages == null)
                {
                    messages = new List<IMessage>();
                }

                messages.Add(message);

                HttpContext.Current.Items["Messages"] = messages;
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
