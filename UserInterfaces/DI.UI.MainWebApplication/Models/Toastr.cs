using DI.Common.Enumerations;
using DI.Core.Messaging.BaseClasses;
using DI.Core.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DI.UI.MainWebApplication.Models
{
    //public enum ToastType
    //{
    //    Error,
    //    Info,
    //    Success,
    //    Warning
    //}

    //public class ToastMessage : MessageBase
    //{
    //    public ToastType ToastType { get; set; }

    //    public string Options { get; set; }
    //}

    //[Serializable]
    //public class Toastr
    //{
    //    public Toastr()
    //    {
    //        Options = "";
    //        ToastrId = new Guid();
    //    }
    //    public Guid ToastrId { get; set; }


    //    public ToastType Type { get; set; }

    //    public String Title { get; set; }

    //    public String Message { get; set; }

    //    public String Details { get; set; }

    //    public string Options { get; set; }

    //    public bool IsSessionToastr { get; set; }

    //    public static List<Toastr> AddToastr(Toastr toast, List<IMessage> Messages)
    //    {

    //        if (Messages == null)
    //        {
    //            Messages = new List<IMessage>();
    //        }

    //        var Toasts = new List<Toastr>();

            
    //        Toasts.Add(toast);

    //        return Toasts;
    //    }

    //    public static List<Toastr> ConvertIMessageToToastr(List<IMessage> Messages)
    //    {
    //        var Toasts = new List<Toastr>();
    //        foreach (IMessage message in Messages)
    //        {
    //            ToastType type = ToastType.Info;
    //            if (message.Type.HasValue)
    //            {
    //                switch (Status.StatusGroup(message.Type.Value))
    //                {
    //                    case StatusCode.OK:
    //                        type = ToastType.Success;
    //                        break;
    //                    case StatusCode.Warning:
    //                        type = ToastType.Warning;
    //                        break;
    //                    case StatusCode.Error:
    //                        type = ToastType.Error;
    //                        break;
    //                    default:
    //                        break;
    //                }
    //            }
    //            Toasts.Add(new Toastr
    //            {
    //                ToastrId = new Guid(),
    //                Type = type,
    //                Title = message.Title,
    //                Message = message.Text,
    //                Details = message.Details,
    //                IsSessionToastr = message.IsPersistent
    //            });
    //        }
    //        return Toasts;
    //    }

    //    public IMessage ToMessage()
    //    {
    //        return new Message
    //        {
    //            //Type = this.Type
    //            //Title = this.Title,

    //        };
    //    }

    //}

    

    //[Serializable]
    //public class ToastrMessage : MessageBase
    //{
    //    public ToastType ToastType
    //    {
    //        get
    //        {
    //            if (base.Type.HasValue)
    //            {
    //                switch (Status.StatusGroup(base.Type.Value))
    //                {
    //                    case StatusCode.OK:
    //                        return ToastType.Success;
    //                    case StatusCode.Warning:
    //                        return ToastType.Warning;
    //                    case StatusCode.Error:
    //                        return ToastType.Error;
    //                    default:
    //                        return ToastType.Info;
    //                }
    //            }
    //            else
    //            {
    //                return ToastType.Info;
    //            }
    //        }
    //        set
    //        {
    //            switch (value)
    //            {
    //                case ToastType.Success:
    //                    base.Type = StatusCode.Success;
    //                    break;
    //                case ToastType.Warning:
    //                    base.Type = StatusCode.Warning;
    //                    break;
    //                case ToastType.Error:
    //                    base.Type = StatusCode.Error;
    //                    break;
    //                default:
    //                    base.Type = StatusCode.OK;
    //                    break;
    //            }
    //        }
    //    }

    //    public String Options { get; set; }

    //    public static void AddToastr(Message message, List<Message> Messages)
    //    {
    //        if (Messages != null)
    //        {
    //            Messages.Add(message);
    //        }
    //        else
    //        {
    //            Messages = new List<Message>();
    //            Messages.Add(new Message
    //            {
    //                Type = StatusCode.Error,
    //                Title = "Unable to load message ",
    //                Text = DateTime.Now.ToString()
    //            });
    //        }
    //    }

        

    //    //public static List<IMessage> AddToastr(IMessage message, List<IMessage> Messages)
    //    //{

    //    //    if (Messages == null)
    //    //    {
    //    //        Messages = new List<IMessage>();
    //    //    }

    //    //    var Toasts = new List<IMessage>();


    //    //    Toasts.Add(message);

    //    //    return Toasts;
    //    //}
    //}

    //public class ToastrConversions
    //{
    //    public static void AddToastr(Message toast, ref List<Message> MessageList)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public static ToastType GetToastTypeFromStatusCode(StatusCode? statusCode = StatusCode.OK)
    //    {
    //        if (statusCode.HasValue)
    //        {
    //            switch (Status.StatusGroup(statusCode.Value))
    //            {
    //                case StatusCode.OK:
    //                    return ToastType.Success;
    //                case StatusCode.Warning:
    //                    return ToastType.Warning;
    //                case StatusCode.Error:
    //                    return ToastType.Error;
    //                default:
    //                    return ToastType.Info;
    //            }
    //        }
    //        return ToastType.Info;
    //    }

    //    public static StatusCode GetStatusCodeFromToastType(ToastType toastType = ToastType.Info)
    //    {
    //        switch (toastType)
    //        {
    //            case ToastType.Success:
    //                return StatusCode.Success;
    //            case ToastType.Warning:
    //                return StatusCode.Warning;
    //            case ToastType.Error:
    //                return StatusCode.Error;
    //            default:
    //                return StatusCode.OK;
    //        }
    //    }

    //    public static List<Message> GetMessageListFromIMessageList(List<IMessage> Messages)
    //    {
    //        var MessageList = new List<Message>();
    //        if (Messages != null)
    //        {
    //            foreach (Message message in Messages)
    //            {
    //                MessageList.Add(new Message
    //                {
    //                    Type = message.Type,
    //                    Title = message.Title,
    //                    Text = message.Text,
    //                    Details = message.Details,
    //                    MailMessage = message.MailMessage,
    //                    IsPersistent = message.IsPersistent,
    //                    ResponseCode = message.ResponseCode,
    //                    ResponseText = message.ResponseText
    //                });
    //            }
    //        }

    //        return (List<Message>)MessageList;
    //    }
    //}
}