using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace web1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // master method 名稱不可更改
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// master method
        /// 依造 dotnet 類型加入設定(複寫)
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Host.CreateDefaultBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
