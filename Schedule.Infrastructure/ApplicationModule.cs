using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Schedule.Application;

namespace Schedule.Infrastructure
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationModuleException).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
