using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// 設定相依注入 (DI Context)，每個服務只會被實例化一次
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 應用程式初始方法(類似 main)，接取 webserver Request 並回應
        /// 為遞迴執行(包含 next 方法)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 裝載的環境(預設 Development，設定環境變數就可更改(set ASPNETCORE_ENVIRONMENT=Production，會與 launch.json 衝突)
            if (env.IsDevelopment())
            {
                // Unhandle Exception 導至預設頁面
                app.UseDeveloperExceptionPage();
            }
            // 加入 路由
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // 根網址
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
