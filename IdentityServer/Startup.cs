using IdentityServerSample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddOperationalStore(options =>
            //    {
            //        options.EnableTokenCleanup = true;
            //        options.TokenCleanupInterval = 30;
            //    })
            //    //.AddInMemoryApiResources(IdentityConfiguration.GetApiResource())
            //    .AddInMemoryIdentityResources(IdentityConfiguration.GetIdentityResources())
            //    .AddInMemoryClients(IdentityConfiguration.GetClients());

                 services.AddIdentityServer()
                .AddInMemoryClients(IdentityConfiguration.GetClients())
                .AddInMemoryIdentityResources(IdentityConfiguration.GetIdentityResources())
                .AddInMemoryApiResources(IdentityConfiguration.GetApiResources())
                .AddInMemoryApiScopes(IdentityConfiguration.GetApiScopes())
                .AddTestUsers(Users.Get())
                .AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
