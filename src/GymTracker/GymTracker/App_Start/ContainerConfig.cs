using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using GymTrackerShared.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace GymTracker
{
    public class ContainerConfig
    {
        internal static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GymTrackerMappingProfile());
            });

            builder.RegisterType<IngredientsRepository>()
                .As<IIngredientsRepository>()
                .InstancePerRequest();

            builder.RegisterType<WgerService>()
                .As<IWgerService>()
                .InstancePerRequest();

            builder.RegisterType<AccountDataRepository>()
                .As<IAccountDataRepository>()
                .InstancePerRequest();

            builder.RegisterType<ProgressiveOverloadRepository>()
                .As<IProgressiveOverloadRepository>()
                .InstancePerRequest();

            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            builder.RegisterType<RoutinesRepository>()
                .As<IRoutinesRepository>()
                .InstancePerRequest();

            builder.RegisterType<ExercisesStatsRepository>()
                .As<IExercisesStatsRepository>()
                .InstancePerRequest();

            builder.RegisterType<GymTrackerDbContext>().InstancePerRequest();

            builder.RegisterType<GymUserStore<IdentityUser>>()
                .As<IUserStore<IdentityUser>>()
                .InstancePerRequest();

            builder.RegisterType<GymUserManager<IdentityUser, string>>().InstancePerRequest();

            builder.RegisterType<GymSignInManager<IdentityUser, string>>().InstancePerRequest();
        }
    }
}