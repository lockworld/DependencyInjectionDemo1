using DI.Common.Enumerations;
using DI.Core.Messaging.BaseClasses;
using DI.Core.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DI.Processes.Messaging.ForWebMVC.Models
{
    public enum ToastType
    {
        Error,
        Info,
        Success,
        Warning
    }
    public class Toastr : Message
    {
        public ToastType ToastType
        { //get; set;
            get
            {
                if (base.Type.HasValue)
                {
                    switch (Status.StatusGroup(base.Type.Value))
                    {
                        case StatusCode.OK:
                            return ToastType.Success;
                        case StatusCode.Warning:
                            return ToastType.Warning;
                        case StatusCode.Error:
                            return ToastType.Error;
                        default:
                            return ToastType.Info;
                    }
                }
                else
                {
                    return ToastType.Info;
                }
            }
            set
            {
                switch (value)
                {
                    case ToastType.Success:
                        base.Type = StatusCode.Success;
                        break;
                    case ToastType.Warning:
                        base.Type = StatusCode.Warning;
                        break;
                    case ToastType.Error:
                        base.Type = StatusCode.Error;
                        break;
                    default:
                        base.Type = StatusCode.OK;
                        break;
                }
            }
        }

        //public String Options { get; set; }

        //public StatusCode? Type { get; set; }

        //public string Title { get; set; }

        //public string Text { get; set; }

        //public string Details { get; set; }

        //public MailMessage MailMessage { get; set; }

        //public bool IsPersistent { get; set; }

        //public StatusCode? ResponseCode { get; set; }

        //public string ResponseText { get; set; }
    }

    public class ToastrConversions
    {
        public static void AddToastr(Message message, List<IMessage> Messages)
        {
            if (Messages != null)
            {
                Messages.Add(message);
            }
            else
            {
                throw new NullReferenceException("Object reference (\"Messages\") not set to an instance of an object. Unable to add message " + message.Title + ".");
            }
        }

        public static ToastType GetToastTypeFromStatusCode(StatusCode? statusCode = StatusCode.OK)
        {
            if (statusCode.HasValue)
            {
                switch (Status.StatusGroup(statusCode.Value))
                {
                    case StatusCode.OK:
                        return ToastType.Success;
                    case StatusCode.Warning:
                        return ToastType.Warning;
                    case StatusCode.Error:
                        return ToastType.Error;
                    default:
                        return ToastType.Info;
                }
            }
            return ToastType.Info;
        }

        public static StatusCode GetStatusCodeFromToastType(ToastType toastType = ToastType.Info)
        {
            switch (toastType)
            {
                case ToastType.Success:
                    return StatusCode.Success;
                case ToastType.Warning:
                    return StatusCode.Warning;
                case ToastType.Error:
                    return StatusCode.Error;
                default:
                    return StatusCode.OK;
            }
        }

        public static List<Message> GetMessageListFromIMessageList(List<IMessage> Messages)
        {
            var MessageList = new List<Message>();
            if (Messages != null)
            {
                foreach (IMessage imessage in Messages)
                {
                    Message message = AutoMapper.Mapper.Map<Message>(imessage);

                    MessageList.Add(message);

                }
            }

            return (List<Message>)MessageList;
        }

        public static List<Toastr> GetToastrListFromMessageList(List<Message> Messages)
        {
            var ToastrList = new List<Toastr>();
            if (Messages != null)
            {
                foreach (Message message in Messages)
                {
                    Toastr toast = AutoMapper.Mapper.Map<Toastr>(message);
                    ToastrList.Add(toast);

                }
            }

            return (List<Toastr>)ToastrList;
        }

        public static List<Toastr> GetToastrListFromIMessageList(List<IMessage> IMessages)
        {
            var ToastrList = new List<Toastr>();
            if (IMessages != null)
            {
                foreach (IMessage imessage in IMessages)
                {
                    Message message = AutoMapper.Mapper.Map<Message>(imessage);
                    Toastr toast = new Toastr
                    {
                        Title = "Toast",
                        Type = StatusCode.Error,
                        Text = "Nothing to say"
                    };
                    ToastrList.Add(toast);

                }
            }

            return (List<Toastr>)ToastrList;
        }
    }

}
