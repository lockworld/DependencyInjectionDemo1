using DI.Common.Enumerations;
using DI.Core.Messaging.Interfaces;
using DI.Processes.Messaging.ForWeb.Entities;
using DI.UI.MainWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DI.UI.MainWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        public ActionResult Index()
        {
            var toast = new Toastr
            {
                Type = StatusCode.OK,
                Title = "Sample Info Message",
                Text = "This is a sample web message.",
                IsPersistent = true
            };
            _messageService.WriteMessage(toast);

            toast = new Toastr
            {
                Type = StatusCode.Warning,
                Title = "This is Warning Message",
                Text = "This is a sample web message.",
                IsPersistent = true
            };
            _messageService.WriteMessage(toast);

            toast = new Toastr
            {
                Type = StatusCode.Failure,
                Title = "Simulated Failure Message",
                Text = "This is a sample web message.",
                IsPersistent = true
            };
            _messageService.WriteMessage(toast);

            try
            {
                List<IMessage> temp = (List<IMessage>)ControllerContext.HttpContext.Items["Messages"];
                ViewBag.Title = temp.Count.ToString() + " Messages";
            }
            catch (Exception ex)
            {
                ViewBag.Title = ex.Message.ToString();
            }

            //var Toasts = (List<ToastrMessage>)ControllerContext.HttpContext.Items["Messages"];
            //ToastrMessage.AddToastr(toast, ref Toasts);
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}