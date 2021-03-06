﻿using DI.Core.Messaging.Interfaces;
using DI.Processes.Messaging.ForWeb;
using DI.Services.Messaging;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DI.UI.MainWebApplication.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IMessageService>().To<MessageService>();
            _kernel.Bind<IMessageRepository>().To<MessagingForWebRepository>();

        }
    }
}
