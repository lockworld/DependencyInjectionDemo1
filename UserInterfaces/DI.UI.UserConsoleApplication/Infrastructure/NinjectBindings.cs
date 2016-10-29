using DI.Core.Messaging.Interfaces;
using DI.Processes.Messaging.ForConsole;
using DI.Services.Messaging;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.UI.UserConsoleApplication.Infrastructure
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IMessageService>().To<MessageService>();
            Bind<IMessageRepository>().To<MessagingForConsoleRepository>();
        }
    }
}
