using AcademyC.Week4.Test.Core.BusinessLayer;
using AcademyC.Week4.Test.Core.Repositories;
using AcademyC.Week4.Test.CoreEF;
using AcademyC.Week4.Test.CoreEF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AcademyC.Week4.Test.OrderAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //public readonly string ApplicationName = Assembly.GetEntryAssembly().GetName().Name;
        //public readonly string ApplicationVersion =
        //    $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
        //    $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
        //    $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            
            
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Client_Order_ManagementDB"));
            });

            //services.AddSwaggerGen(c =>
            //{
            //    //Head information
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = ApplicationName,
            //        Version = ApplicationVersion
            //    });

            //    //Add comments for controllers
            //    string file = $"{typeof(Startup).Assembly.GetName().Name}.xml";
            //    string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            //    c.IncludeXmlComments(xmlPath);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Enable swagger 
            //app.UseSwagger();

            ////Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("v1/swagger.json", $"{ApplicationName} {ApplicationVersion}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
