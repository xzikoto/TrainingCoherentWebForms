using Autofac;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebFormsTrainingSecondTask.Infrastructure;
using WebFormsTrainingSecondTask.Infrastructure.Core;
using WebFormsTrainingSecondTask.Service_Provider;
using WebFormsTrainingSecondTask.Services;
using WebFormsTrainingSecondTask.Services.Contracts;

namespace WebFormsTrainingSecondTask
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Better connection string providing for AppContext
            // Better validation in Services 
            var builder = new ContainerBuilder();
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerLifetimeScope();

            builder.RegisterSource(new WebFormRegistrationSource());
            var container = builder.Build();
            var provider = new AutofacServiceProvider(container);
            HttpRuntime.WebObjectActivator = provider;

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}