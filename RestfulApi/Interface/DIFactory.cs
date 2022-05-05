using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositorys;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulApi.Interface
{
    public static class DIFactory
    {
        public static IContainer Container { get; }

        public static IServiceProvider ContainerBuilderAutofac(this IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmployeeConfigRepository>()
                .As<IEmployeeConfigRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoginService>()
                .As<ILoginService>()
                .InstancePerLifetimeScope();

            return new AutofacServiceProvider(builder.Build());
        }

        public static void DisposeAutofac(this IApplicationLifetime appLifetime)
        {
            appLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
