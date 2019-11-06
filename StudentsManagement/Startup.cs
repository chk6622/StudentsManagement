using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentsManagement.Models;

namespace StudentsManagement
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options=>options.UseSqlServer(_configuration.GetConnectionString("StudentDBConnection"))
                );
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped<IStudentRepository, SQLStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions();
                developerExceptionPageOptions.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            else if (env.IsStaging()||env.IsProduction()||env.IsEnvironment("UAT"))
            {
                Console.WriteLine("aaa");
                app.UseExceptionHandler("/Error");
            }

            //#region setting default page, default using index.html and default.html
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();

            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("52app.html");

            ////default file middleware
            //app.UseDefaultFiles(defaultFilesOptions);
            //#endregion

            ////static file middleware eg: html,image tec
            app.UseStaticFiles();

            #region UseDefaultFiles+UseStaticFiles
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("52app.html");

            //app.UseFileServer(fileServerOptions);
            #endregion

            #region add mvc function
            //app.UseMvcWithDefaultRoute();
            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            }
                );

            //app.UseMvc();

        }
    }
}
