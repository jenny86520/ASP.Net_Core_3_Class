using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebAPI
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
            /** Class-1214: 啟用 ASP.NET Core 的 CORS 支援 
            回傳 header 加上「Access-Control-Allow-Origin: http://localhost:5000」
            */
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:5000")     // 放 Client 端的網址(不包含尾端的斜線)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /** Class-1214: 啟用 ASP.NET Core 的 CORS 支援 */
            app.UseCors();
            app.UseMvc();
        }
    }
}
