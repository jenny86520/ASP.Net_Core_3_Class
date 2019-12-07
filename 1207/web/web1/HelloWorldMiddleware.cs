using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace web1
{
    /** Class-1207: 練習基本 Middleware 設計 - 3 */
    public static class MiddlewarePack
    {
        public static void UseHelloWorld(this IApplicationBuilder app)
        {
            app.UseMiddleware<HelloWorldMiddleware>();
        }
    }
    /** Class-1207: 練習基本 Middleware 設計 - 2 */
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate _next;
        private HelloWorldMessage _helloWorldMsg;


        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public HelloWorldMiddleware(RequestDelegate next, HelloWorldMessage helloWorldMsg)
        {
            _next = next;
            _helloWorldMsg = helloWorldMsg; // Class-1207: 練習用 DI 注入物件到其他服務中
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello");
            await _next(context);
            await context.Response.WriteAsync("World");
            /** Class-1207: 練習用 DI 注入物件到其他服務中 */
            await context.Response.WriteAsync(_helloWorldMsg.Message);
        }
    }
}
