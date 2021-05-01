using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NeoSoft.Day2.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeoSoft.Day2.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            //  master pipeline
            return
                 app
                 .UseDeveloperExceptionPage(env)
                 .UseCustomMiddleware()
                 .UseRoutingWithEndpoints();
        }

        private static IApplicationBuilder UseDeveloperExceptionPage(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            return app;
        }

        private static IApplicationBuilder UseRoutingWithEndpoints(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }

        private static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AppCustomMiddleware>();


            return app;
        }
    }
}
