using DI.Common.Enumerations;
using DI.Core.Messaging.BaseClasses;
using DI.Core.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DI.Processes.Messaging.ForConsole.Entities
{
    public class Message : MessageBase
    {
        private string _typeString;

        // This is just an example to show that you can override the message definition within your process layer.
        public override StatusCode Type
        {
            get
            {
                try
                {
                    StatusCode code = (StatusCode)System.Enum.Parse(typeof(StatusCode), _typeString, true);
                    return code;
                }
                catch
                {
                    return StatusCode.Null;
                }
            }
            set
            {
                _typeString = value.ToString();
            }
        }
    }
}
