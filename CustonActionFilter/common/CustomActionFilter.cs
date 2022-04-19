using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace CustonActionFilter.common
{
    public class CustomActionFilter:ActionFilterAttribute,IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string message= "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "->" +
                filterContext.ActionDescriptor.ActionName + "->OnActionExecuting" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
       public override void  OnActionExecuted(ActionExecutedContext filterContext)
        {
            string message = "\n" + filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "->" +
               filterContext.ActionDescriptor.ActionName + "->OnActionExecuted" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + "->" +
            filterContext.RouteData.Values["action"] + "->OnResultExecuting" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + "->" +
           filterContext.RouteData.Values["action"] + "->OnResultExecuted" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("--------------------------------------------------------------");
        }
        public void  OnException(ExceptionContext filterContext)
        {
            string message = "\n" + filterContext.RouteData.Values["controller"].ToString() + "->" +
           filterContext.RouteData.Values["action"] + "->"+filterContext.Exception.Message + DateTime.Now.ToString() + "\n";
            LogExecutionTime(message);
            LogExecutionTime("--------------------------------------------------------------");
        }
        private void LogExecutionTime(string data)
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), data);
        }
    }
}