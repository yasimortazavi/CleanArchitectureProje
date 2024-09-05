using Devsharp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
using System.Threading.Tasks;

namespace ShopProjectG1
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
            //services.AddScoped<IApplcationDbContext, ApplicationDbContext>();
            //services.AddDbContext<IApplcationDbContext, ApplicationDbContext>(
            //    (Options) =>
            //{
            //    Options.UseSqlServer("Data Source=.;Initial Catalog=ShopWebApi;Integrated Security=true;");
            //}, optionsLifetime: ServiceLifetime.Scoped);


            services.AddDbContextPool<IApplcationDbContext, ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=.;Initial Catalog=ShopG1;Integrated Security=true;")
            , poolSize: 16);
            services.AddControllers();
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Data Source=.; Initial Catalog=shop;Integrated Security=True;"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Run(
            //    async (HttpContext) =>
            //    await HttpContext.Response.WriteAsync("salam")

            //    ) ;
        }
    }
}
