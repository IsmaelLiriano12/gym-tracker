﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(GymTracker.Startup))]

namespace GymTracker
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/user/login")
            });
        }
    }
}
