using Autofac.Integration.WebApi;
using AutoMapper;
using GymTracker.DependencyResolvers;
using GymTrackerShared.Data;
using GymTrackerShared.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(GymTracker.Startup))]

namespace GymTracker
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t) && 
                            typeof(IHttpController).IsAssignableFrom(t) ||
                            t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GymTrackerMappingProfile());
            });

            services.AddDbContext<GymTrackerDbContext>();

            services.AddScoped<IProfileDataRepository, ProfileDataRepository>();

            services.AddScoped<IProgressiveOverloadRepository, ProgressiveOverloadRepository>();

            services.AddSingleton(config.CreateMapper());

            services.AddScoped<IRoutinesRepository, RoutinesRepository>();

            services.AddScoped<IExercisesRepository, ExercisesRepository>();

            services.AddScoped<IUserStore<IdentityUser>, GymUserStore<IdentityUser>>();

            services.AddScoped<GymUserManager<IdentityUser, string>>();

            services.AddScoped<GymSignInManager<IdentityUser, string>>();
        }

        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
            var webApiResolver = new DefaultWebApiDependencyResolver(services.BuildServiceProvider());
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = webApiResolver;
            

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
