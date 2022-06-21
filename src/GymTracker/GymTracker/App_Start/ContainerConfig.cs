using Autofac;
using Autofac.Integration.Mvc;
using GymTrackerShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<RoutinesRepository>()
                .As<IRoutinesRepository>()
                .InstancePerRequest();

            builder.RegisterType<ExercisesRepository>()
                .As<IExercisesRepository>()
                .InstancePerRequest();

            builder.RegisterType<AddProgressiveOverload>()
                .As<IAddProgressiveOverload>()
                .InstancePerRequest();

            builder.RegisterType<Context>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}