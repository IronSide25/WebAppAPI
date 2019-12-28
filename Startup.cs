using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models;

using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WebAppAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ProjectContext>(opt => opt.UseInMemoryDatabase("CarList"));
            services.AddDbContext<ProjectContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<IdentityDbContext>(opt => opt.UseInMemoryDatabase("Test"));
            services.AddControllers();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddCors(options =>
            {
                options.AddPolicy("allowPolicy",
                    builder => {
                        builder.
               //AllowAnyOrigin().
               WithOrigins("http://localhost:4200").
               AllowAnyHeader().
               AllowAnyMethod();
                    });
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ProjectContext>()
                    .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;

                    return Task.CompletedTask;
                };
            });

            services.AddAuthentication(options =>
            {
                //options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                options.DefaultSignOutScheme = IdentityConstants.ApplicationScheme;
            })
            .AddGoogle("Google", options =>
            {
                options.CallbackPath = new PathString("/signin-google");
                options.ClientId = "733418871615-mfuekqds6uk5o0v335n1kaii033dio3a.apps.googleusercontent.com";
                options.ClientSecret = "yF7KglFj-WjpQA03LAYZZw6q";
                options.Events = new OAuthEvents
                {
                    OnRemoteFailure = (RemoteFailureContext context) =>
                    {
                        context.Response.Redirect("/home/denied");
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }/*,
                    OnAccessDenied = (AccessDeniedContext context) =>
                    {
                        context.Response.Redirect("/home/denied");
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }  */                  
                };
            })
            .AddMicrosoftAccount("MicrosoftAccount", options =>
            {
                options.CallbackPath = new PathString("/signin-microsoft");
                options.ClientId = "4cc717ab-44b4-46bd-b598-8a9d85b27cda";
                options.ClientSecret = "?Aohy5qpiQmiqClhy:fB4_/2Gs5.UJOK";
                options.Events = new OAuthEvents
                {
                    OnRemoteFailure = (RemoteFailureContext context) =>
                    {
                        context.Response.Redirect("/home/denied");
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }/*,
                    OnAccessDenied = (AccessDeniedContext context) =>
                    {
                        context.Response.Redirect("/home/denied");
                        context.HandleResponse();
                        return Task.CompletedTask;
                    }*/
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("allowPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();//app.UseAuthorization();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
            app.UseMvcWithDefaultRoute();
        }
    }
}
