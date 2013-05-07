using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.Release(controller);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)_kernel.Get(controllerType);
        }
    }
}