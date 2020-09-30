using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Dapr.Actors;
using Dapr.Actors.AspNetCore;
using Microsoft.AspNetCore;

namespace MyActor.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseActors(actorRuntime => {
                actorRuntime.RegisterActor<MyActor>();
            });
            //Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder.UseStartup<Startup>();
            //        webBuilder.UseActors(actorRuntime => {

            //            //registering myactor actor type
            //            actorRuntime.RegisterActor<MyActor>();
            //        });
            //    });
    }
}
