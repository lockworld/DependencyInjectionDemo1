using DI.Common.Enumerations;
using System;
using System.Net.Mail;

namespace DI.Core.Messaging.Interfaces
{
    public interface IMessage
    {
        StatusCode Type { get; set; }

        String Title { get; set; }

        String Text { get; set; }

        String Details { get; set; }

        MailMessage MailMessage { get; set; }

        Boolean IsPersistent { get; set; }

        StatusCode ResponseCode { get; set; }

        String ResponseText { get; set; }

    }
}
