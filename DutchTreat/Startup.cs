using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // adding identity but no real security (cookie based authentication)
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DutchContext>();

            // token based authentication
            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };

                });

            services.AddDbContext<DutchContext>(cfg =>
            {
                // in memory is used for testing 
                // must pass a connection string into here (Configuration)
                cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
            });

            services.AddAutoMapper();

            services.AddTransient<IMailService, NullMailService>(); // Support for real mail service
            services.AddTransient<DutchSeeder>();


            // Add IDutchRepository as a service that people can use as the implementation DutchRepository
            services.AddScoped<IDutchRepository, DutchRepository>();
            
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) // allows self referencing loop in orders
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1); // magic that deals with the response type
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // for developer use only and shows a developer exception page with a stack trace...
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            

            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseNodeModules(env);

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", 
                    "/{controller}/{action}/{id?}", 
                    new { controller = "App", Action="Index"});
            });
        }
    }
}
