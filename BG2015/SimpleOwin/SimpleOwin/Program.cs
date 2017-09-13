using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace SimpleOwin
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Started");
                Console.ReadLine();
                Console.WriteLine("Finished");
            }
        }

    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage();

            app.Use(async (ctx, next) =>
            {
                foreach (var item in ctx.Environment)
                {
                    Console.WriteLine("{0}: {1}", item.Key, item.Value);
                }
                await next();
            });

            //app.Use<HelloWorldComponent>();
            app.UseHelloWorld();

            //app.Run(ctx => ctx.Response.WriteAsync("Hello, World"));
        }
    }

    public class HelloWorldComponent
    {
        private readonly AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var response = env["owin.ResponseBody"] as Stream;

            using (var writer = new StreamWriter(response))
            {
                await writer.WriteAsync("Goodbye cruel world, I'm leaving you today");
            }

            await _next(env);
        }
    }

    public static class HelloWorldExtension
    {
        public static void UseHelloWorld(this IAppBuilder builder)
        {
            builder.Use<HelloWorldComponent>();
        }
    }
}
