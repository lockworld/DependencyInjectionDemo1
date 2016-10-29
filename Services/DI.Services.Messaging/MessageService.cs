using DI.Common.Enumerations;
using DI.Core.Messaging.Interfaces;
using System;

namespace DI.Services.Messaging
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repo;
        
        public MessageService(IMessageRepository repository)
        {
            _repo = repository;
        }
        
        private enum MessageType
        {
            Email,
            Write
        }


        public void EmailMessage(IMessage message)
        {
            if (ValidateMessage(message, MessageType.Email) == StatusCode.OK)
            {
                _repo.EmailMessage(message);
                message.ResponseCode = StatusCode.OK;
            }
        }

        public StatusCode EmailMessage(IMessage message, string response=null)
        {
            try
            {
                EmailMessage(message);
                response = StatusCode.OK.ToString();
                return StatusCode.OK;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return StatusCode.Error;
            }
        }

        public void WriteMessage(IMessage message)
        {
            if (ValidateMessage(message, MessageType.Write) == StatusCode.OK)
            {
                _repo.WriteMessage(message);
            }
        }

        public StatusCode WriteMessage(IMessage message, string response=null)
        {
            try
            {
                WriteMessage(message);
                response = StatusCode.OK.ToString();
                return StatusCode.OK;
            }
            catch (Exception ex)
            {
                response = ex.ToString();
                return StatusCode.Error;
            }
        }

        
        private StatusCode ValidateMessage(IMessage message, MessageType messageType)
        {
            if (messageType==MessageType.Email)
            {
                if (message.MailMessage!=null
                    && message.MailMessage.To!=null
                    && message.MailMessage.Body!=null)
                {
                    return StatusCode.OK;
                }
                message.ResponseText +=
                    ((message.MailMessage == null) ? "MailMessage cannot be null. " : "");
                if (message.MailMessage!=null)
                {
                    message.ResponseText +=
                        ((message.MailMessage.To == null) ? "To field cannot be null. " : "")
                        + ((message.MailMessage.From == null) ? "From field cannot be null. " : "");
                }
            }
            else if (messageType==MessageType.Write)
            {
                if (!string.IsNullOrEmpty(message.Text))
                {
                    return StatusCode.OK;
                }
                message.ResponseText += "Message text cannot be empty. ";
            }

            message.ResponseCode = StatusCode.Error;
            message.ResponseText = "Error: Unable to process" + messageType.ToString() + " message: MESSAGE DID NOT PASS VALIDATION...\r\n" + message.Type.ToString() + "\r\n" + message.Text + "\r\n" + message.ResponseText;
            throw new System.ArgumentException(message.ResponseText);
            
        }
        
    }
}
