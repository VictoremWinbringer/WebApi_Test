using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPA.Models
{
    public class MyNinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public MyNinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}