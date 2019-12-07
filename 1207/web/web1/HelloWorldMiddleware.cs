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

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public HelloWorldMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello");
            await _next(context);
            await context.Response.WriteAsync("World");
        }
    }
}
