using BlazorPersonalWebsite.DataAccess;
using BlazorPersonalWebsite.EntityFramework;
using BlazorPersonalWebsite.Models.Interfaces;
using BlazorPersonalWebsite.RestApi.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPersonalWebsite.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static string CorsPolicy = "AllowOrigin";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbContext = Configuration.GetConnectionString("DBContext");

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(path: "logs\\log.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services
                .AddLogging(builder => builder.AddSerilog())
                .AddDbContext<WebsiteContext>(options => options
                    .EnableSensitiveDataLogging(true)
                    .EnableDetailedErrors(true)
                    .UseSqlite(dbContext))
                .AddScoped<IJobApplicationRepository, JobApplicationRepository>()
                .AddScoped<ISoftwareProjectRepository, SoftwareProjectRepository>()
                .AddScoped<IWoodworkProjectRepository, WoodworkProjectRepository>()
                .AddAutoMapper(typeof(SoftwareProjectProfile), typeof(WoodworkProjectProfile))
                .AddCors(c =>
                {
                    c.AddPolicy(CorsPolicy, options => options
                                                        .AllowAnyOrigin()
                                                        .AllowAnyMethod()
                                                        .AllowAnyHeader());
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlazorPersonalWebsite.RestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorPersonalWebsite.RestApi v1"));
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<WebsiteContext>();
                db.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
