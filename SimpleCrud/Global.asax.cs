using Ninject;
using SimpleCrud.Controllers;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validator;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleCrud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var kernel = new StandardKernel();

            AddBindings(kernel);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IPersonsRepository>().To<PersonsRepository>();
            kernel.Bind<PersonController>().To<PersonController>();
            kernel.Bind<IValidator<AddUserModel>>().To<AddUserModelValidator>();
        }
    }
}
