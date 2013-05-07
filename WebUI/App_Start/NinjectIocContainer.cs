using Ninject;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.App_Start
{
    public class NinjectIocAdapter : IContainerAdapter
    {
        private readonly IKernel _kernel;

        public NinjectIocAdapter(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public T TryResolve<T>()
        {
            return _kernel.TryGet<T>();
        }
    }
}