using DI.Core.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DI.Common.Enumerations;

namespace DI.Core.Messaging.BaseClasses
{
    public class MessageBase : IMessage
    {
        public virtual StatusCode Type { get; set; }

        public virtual String Title { get; set; }

        public virtual String Text { get; set; }

        public virtual String Details { get; set; }

        public virtual MailMessage MailMessage { get; set; }
        
        public virtual bool IsPersistent { get; set; }

        private StatusCode _responseCode;
        public virtual StatusCode ResponseCode
        {
            get
            {
                return _responseCode;
            }
            set
            {
                StatusCode originalstatus = _responseCode;
                StatusCode newstatus = value;

                int comparer = originalstatus.CompareTo(newstatus);
                if (comparer<0)
                {
                    _responseCode = newstatus;
                }
                else
                {
                    _responseCode = originalstatus;
                }
            }
        }

        private String _responseText { get; set; }

        public virtual String ResponseText
        {
            get
            {
                return _responseText;
            }
            set
            {
                _responseText += ((!String.IsNullOrEmpty(_responseText)) ? "\r\n" : "") + value;
            }
        }
    }
}
