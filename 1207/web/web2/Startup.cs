using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace web2
{
    public class Startup
    {
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="configuration">DI 注入 IConfiguration: 用來讀取設定檔</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // for MVC: 註冊 Controllers & Views 類別(type)，使其成為服務
            services.AddControllersWithViews();
            /** Class-1207: 練習設定組態並注入 IOptionsSnapshot<T> 物件 */
            services.Configure<Profile>(Configuration.GetSection("Profile"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // 強制將 http 轉為 https，於 header 預設設定 30 天
                app.UseHsts();
            }
            // 轉至
            app.UseHttpsRedirection();
            // 存取靜態網頁(wwwroot)
            app.UseStaticFiles();
            // 加入 路由
            app.UseRouting();
            // 加入授權能力
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
