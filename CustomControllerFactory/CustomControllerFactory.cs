using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomControllerFactory
{
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var list = ControllerScanner.Instance.Controllers;
            if (!list.Contains(controllerName) && !"Admin".Equals(requestContext.RouteData.DataTokens["area"]))
            {
                requestContext.RouteData.DataTokens["namespaces"] = new[] { "Framework.Controllers" };
            }
            var controllerType = base.GetControllerType(requestContext, controllerName);
            return base.GetControllerType(requestContext, controllerName);
        }
    }
}