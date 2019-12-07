using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace web1
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
        /// <summary>
        /// 設定相依注入 (DI Context)，每個服務只會被實例化一次
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            /** Class-1207: 練習用 DI 注入物件到其他服務中 */
            // services.AddSingleton<HelloWorldMessage>(new HelloWorldMessage(){
            //     Message = "***Hello World***"
            // });
            /** Class-1207: 從組態提供者取得參數 */
            // services.Configure<HelloWorldMessage>((HelloWorldMsg) =>
            // {
            //     HelloWorldMsg.Message = "***Hello World***";
            // });
            /** Class-1207: 練習讀取組態物件 */
            services.Configure<HelloWorldMessage>(_config.GetSection("Message"));
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
            /** 初始 */
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

            /** Class-1207: 練習基本 Middleware 設計 - 1 
             * >Hello aka World<
            */
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("=練習基本 Middleware 設計 - 1=\n");
                await next();
                await context.Response.WriteAsync("\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync(">");
                await next();
                await context.Response.WriteAsync("<");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello");
                await next();
                await context.Response.WriteAsync("World");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" aka ");
            });
            /** Class-1207: 練習基本 Middleware 設計 - 2 
             * Hello aka World
            */
            // 自訂 Middleware
            app.UseMiddleware<HelloWorldMiddleware>();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" aka ");
            });
            /** Class-1207: 練習基本 Middleware 設計 - 3
             * Hello aka World
            */
            app.UseHelloWorld();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(" aka ");
            });

        }
    }
}
